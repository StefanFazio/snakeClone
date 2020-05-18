using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRenderer, IGUIClient
    {
        private GameControl gameControl;

        public MainWindow()
        {
            InitializeComponent();
            gameControl = new GameControl(this);
            highscoreListView.ItemsSource = gameControl.GetHighscoreForGUI();
            ShowDescription();
        }

        #region Button Events

        private void ResumeGameClick(object sender, RoutedEventArgs e)
        {
            ShowPanel(gamePanel);
            ShowGameObjects();
            gameControl.ResumeGame();
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            ShowPanel(gamePanel);
            gameControl.NewGame(this);
        }

        private void CreditsClick(object sender, RoutedEventArgs e)
        {
            ShowPanel(creditsPanel);
        }

        private void CreditsOKClick(object sender, RoutedEventArgs e)
        {
            ShowPanel(mainMenuPanel);
        }

        private void HighscoreClick(object sender, RoutedEventArgs e)
        {
            highscoreListView.Items.Refresh();
            ShowPanel(highscorePanel);
        }

        private void HighscoreOkClick(object sender, RoutedEventArgs e)
        {
            ShowPanel(mainMenuPanel);
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        #endregion

        private void ShowDescription()
        {
            new DescriptionWindow().ShowDialog();
            ShowPanel(mainMenuPanel);
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ShowPanel(mainMenuPanel);
                gameControl.PauseGame();
                HideGameObjects();
            }

            if (gameControl.GameIsRunning())
            {
                switch (e.Key)
                {
                    case Key.A:
                    case Key.Left:
                        DirectionControl.SetTurn(Turn.Conterclockwise);
                        break;

                    case Key.D:
                    case Key.Right:
                        DirectionControl.SetTurn(Turn.Clockwise);
                        break;
                }
            }

        }
        
        public void RenderObject(object objectToRender)
        {
            var shape = (Shape)objectToRender;
            playgroundCanvas.Children.Add(shape);
        }

        public void ClearScreen()
        {
            playgroundCanvas.Children.Clear();
        }

        public void SetVisibilityOfResume(bool show)
        {
            resumeGameButton.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
        }

        private void HideGameObjects()
        {
            foreach (var gameObject in playgroundCanvas.Children)
            {
                if (gameObject is Shape)
                    (gameObject as Shape).Visibility = Visibility.Hidden;
            }
        }

        private void ShowGameObjects()
        {
            foreach (var gameObject in playgroundCanvas.Children)
            {
                if (gameObject is Shape)
                    (gameObject as Shape).Visibility = Visibility.Visible;
            }
        }

        public void UpdatePoints(int points)
        {
            textBlockPoints.Text = string.Format("Points: {0}", points);
        }

        public void UpdateTime(string time)
        {
            textBlockPlayTime.Text = string.Format("Time: {0}", time);
        }

        public void ShowGameOver()
        {
            var gameOverScreen = new GameOverWindow();
            gameOverScreen.ShowDialog();
            HideGameObjects();
            ShowPanel(mainMenuPanel);
        }

        private void ShowPanel(Panel panelToShow)
        {
            HidePanel(mainMenuPanel);
            HidePanel(highscorePanel);
            HidePanel(creditsPanel);

            panelToShow.Visibility = Visibility.Visible;
        }

        private void HidePanel(Panel panelToHide)
        {
            panelToHide.Visibility = Visibility.Hidden;
        }
    }
}
