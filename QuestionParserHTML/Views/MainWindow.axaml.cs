using Avalonia.Input;
using Avalonia.Controls;
using System;
using QuestionParserHTML.Services;
using Avalonia.Interactivity;
using Tmds.DBus.Protocol;

namespace QuestionParserHTML.Views
{
    public partial class MainWindow : Window
    {
        HTMLParserService hTMLParserService = new HTMLParserService();
        public MainWindow()
        {
            this.ClientSize= new Avalonia.Size(500, 520);
            InitializeComponent();
        }

        private void InputContext_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(InputContext.Text == null)
                return;

            OuputContext.Text = hTMLParserService.GetQuestionData(InputContext.Text).StringValue();
            Status.Text = "Parsing Completed!";
        }

        private void ClickHandler(object sender, RoutedEventArgs args)
        {
            InputContext.Text = null;
            Status.Text = "Input Cleared!";
        }
    }
}