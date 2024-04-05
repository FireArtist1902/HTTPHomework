using System.Text.Json;

namespace HTTPHomework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage message = new HttpRequestMessage())
                {
                    message.Method = HttpMethod.Get;
                    message.RequestUri = new Uri($"https://www.omdbapi.com/?t={textBox1.Text}&plot=full&apikey=e014be01");
                    HttpResponseMessage resp = await client.SendAsync(message);
                    string body = await
                    resp.Content.ReadAsStringAsync();
                    Film film = JsonSerializer.Deserialize<Film>(body);
                    textBox2.Text = film.ToString();
                }
            }
        }
    }
}