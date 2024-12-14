using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class ChatbotForm : Form
    {
        private readonly HttpClient httpClient;
        private readonly string API_KEY = "AIzaSyA2Gi_z_tFBFVtBhvY8KhuQe52VuAVknJk";
        private readonly string API_ENDPOINT = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent";

        public ChatbotForm()
        {
            InitializeComponent();
            httpClient = new HttpClient();

            // Show centered welcome message
            AddCenteredWelcomeMessage();

            userInputBox.Focus();
        }

        



        private async Task<string> GetAIResponse(string prompt)
        {
            try
            {
                var requestBody = new JObject(
                    new JProperty("contents", new JArray(
                        new JObject(
                            new JProperty("parts", new JArray(
                                new JObject(
                                    new JProperty("text", prompt)
                                )
                            ))
                        )
                    ))
                );

                var content = new StringContent(requestBody.ToString(), System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(
                    $"{API_ENDPOINT}?key={API_KEY}",
                    content
                );

                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error: {responseString}");
                }

                // Parse the response using JObject
                var jsonResponse = JObject.Parse(responseString);
                var text = jsonResponse["candidates"][0]["content"]["parts"][0]["text"].ToString();

                return text ?? "No response generated";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while making API request: {ex.Message}");
            }
        }

        private void DisplaySystemMessage(string message)
        {
            if (chatHistoryBox.InvokeRequired)
            {
                chatHistoryBox.Invoke(new Action(() => DisplaySystemMessage(message)));
                return;
            }

            chatHistoryBox.AppendText($"System: {message}\n\n");
            chatHistoryBox.ScrollToCaret();
        }
        private bool isFirstMessage = true;

        private void DisplayUserMessage(string message)
        {
            if (chatHistoryBox.InvokeRequired)
            {
                chatHistoryBox.Invoke(new Action(() => DisplayUserMessage(message)));
                return;
            }

            if (isFirstMessage)
            {
                chatHistoryBox.Clear();
                isFirstMessage = false;
            }

            // Set default alignment to left
            chatHistoryBox.SelectionAlignment = HorizontalAlignment.Left;

            // User message with a light blue background
            chatHistoryBox.SelectionBackColor = Color.LightBlue;
            chatHistoryBox.SelectionColor = Color.Black;
            chatHistoryBox.SelectionFont = new Font("Segoe UI", 10F);

            // Add some padding to the message
            chatHistoryBox.AppendText($"You: {message}\n");

            // Add timestamp
            chatHistoryBox.SelectionBackColor = Color.Transparent;
            chatHistoryBox.SelectionColor = Color.Gray;
            chatHistoryBox.SelectionFont = new Font("Segoe UI", 8F);
            chatHistoryBox.AppendText($"{DateTime.Now:HH:mm}\n\n");

            chatHistoryBox.ScrollToCaret();
        }

        private void DisplayAIMessage(string message)
        {
            if (chatHistoryBox.InvokeRequired)
            {
                chatHistoryBox.Invoke(new Action(() => DisplayAIMessage(message)));
                return;
            }

            // Set default alignment to left
            chatHistoryBox.SelectionAlignment = HorizontalAlignment.Left;

            // AI message with a light gray background
            chatHistoryBox.SelectionBackColor = Color.LightGray;
            chatHistoryBox.SelectionColor = Color.Black;
            chatHistoryBox.SelectionFont = new Font("Segoe UI", 10F);

            // Add some padding to the message
            chatHistoryBox.AppendText($"AI: {message}\n");

            // Add timestamp
            chatHistoryBox.SelectionBackColor = Color.Transparent;
            chatHistoryBox.SelectionColor = Color.Gray;
            chatHistoryBox.SelectionFont = new Font("Segoe UI", 8F);
            chatHistoryBox.AppendText($"{DateTime.Now:HH:mm}\n\n");

            chatHistoryBox.ScrollToCaret();
        }

        private void ProcessLineWithFormatting(string line)
        {
            int currentIndex = 0;
            chatHistoryBox.SelectionColor = Color.Black;
            chatHistoryBox.SelectionFont = new Font(chatHistoryBox.Font, FontStyle.Regular);

            while (currentIndex < line.Length)
            {
                int boldStart = line.IndexOf("**", currentIndex);
                if (boldStart == -1)
                {
                    // No more bold text, append the rest normally
                    chatHistoryBox.AppendText(line.Substring(currentIndex));
                    break;
                }

                // Append text before the bold section
                if (boldStart > currentIndex)
                {
                    chatHistoryBox.AppendText(line.Substring(currentIndex, boldStart - currentIndex));
                }

                int boldEnd = line.IndexOf("**", boldStart + 2);
                if (boldEnd == -1)
                {
                    // Unclosed bold, treat rest as normal text
                    chatHistoryBox.AppendText(line.Substring(boldStart));
                    break;
                }

                // Extract and append the bold text
                string boldText = line.Substring(boldStart + 2, boldEnd - (boldStart + 2));
                chatHistoryBox.SelectionFont = new Font(chatHistoryBox.Font, FontStyle.Bold);
                chatHistoryBox.AppendText(boldText);
                chatHistoryBox.SelectionFont = new Font(chatHistoryBox.Font, FontStyle.Regular);

                currentIndex = boldEnd + 2;
            }

            chatHistoryBox.AppendText("\n");
        }

        // Add this method to handle bullet points and other formatting
        private bool ProcessSpecialFormatting(string line)
        {
            // Handle bullet points
            if (line.TrimStart().StartsWith("- "))
            {
                chatHistoryBox.SelectionIndent = 20;
                chatHistoryBox.AppendText("• " + line.TrimStart().Substring(2) + "\n");
                chatHistoryBox.SelectionIndent = 0;
                return true;
            }

            // Handle numbered lists
            if (System.Text.RegularExpressions.Regex.IsMatch(line, @"^\d+\.\s"))
            {
                chatHistoryBox.SelectionIndent = 20;
                chatHistoryBox.AppendText(line + "\n");
                chatHistoryBox.SelectionIndent = 0;
                return true;
            }

            // Handle headers (lines ending with colon)
            if (line.Contains(":") && !line.Contains("://"))
            {
                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    chatHistoryBox.SelectionFont = new Font(chatHistoryBox.Font, FontStyle.Bold);
                    chatHistoryBox.AppendText(parts[0] + ":");
                    chatHistoryBox.SelectionFont = new Font(chatHistoryBox.Font, FontStyle.Regular);
                    chatHistoryBox.AppendText(parts[1] + "\n");
                    return true;
                }
            }

            return false;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void userInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(userInputBox.Text)) return;

            string userMessage = userInputBox.Text;
            userInputBox.Clear();

            DisplayUserMessage(userMessage);

            try
            {
                sendButton.Enabled = false;
                userInputBox.Enabled = false;

                string contextPrompt = @"You are an AI admission assistant for GABCO Technological University (GABCO). Here's important information about our institution:

HISTORY:
- GABCO was founded by four visionary students—Guerrero, Alampayan, Bautista, and Combo—who shared a common dream of creating a transformative learning institution.
- We are one of the best technological universities in the planet.

AVAILABLE SCHOOLS AND PROGRAMS:
1. School of Law
2. Institute of Art and Design
3. Institute of Nursing
4. Institute of Pharmacy
5. Institute of Accounting
6. College of Business and Finance
7. College of Computing and Information Sciences

APPLICATION PROCESS:
1. Click the 'Apply' button in the navigation bar
2. Create an account through our sign-up page
3. Login with your credentials
4. Fill in all required details (personal information)
5. Submit required documents:
   - 2x2 Picture
   - Birth Certificate
   - Transcript of Records
   - Certificate of Good Moral Character
6. Wait for document approval by administrative system
7. Once approved, check the status page for the examination button
8. Take the timed entrance examination
9. Upon passing, you'll be officially part of GABCO Technological University

IMPORTANT NOTES:
- Document submission is subject to administrative approval
- Entrance exam is timed, so prepare well and answer efficiently
- Regular status checking is recommended
- All documents must be clear and authentic

Please provide accurate and helpful information about GABCO University's admission process, programs, and requirements. If asked about applying, always mention the step-by-step process.";

                string fullPrompt = $"{contextPrompt}\n\nUser Query: {userMessage}";

                var response = await GetAIResponse(fullPrompt);
                DisplayAIMessage(response);
            }
            catch (Exception ex)
            {
                DisplaySystemMessage($"Error: {ex.Message}");
            }
            finally
            {
                sendButton.Enabled = true;
                userInputBox.Enabled = true;
                userInputBox.Focus();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            frmHome AboutPage = new frmHome();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void ChatbotForm_Load(object sender, EventArgs e)
        {
            // Set focus to userInputBox after form loads
            this.BeginInvoke(new Action(() => userInputBox.Focus()));
        }
    }
}