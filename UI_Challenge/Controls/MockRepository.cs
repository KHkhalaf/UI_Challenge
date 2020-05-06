using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace UI_Challenge.Controls
{
    public class MockRepository: ObservableObject
    {
        public Movie currentMovie;
        private int indexMovie = 0;

        public Movie CurrentMovie
        {
            get => currentMovie;
            set => SetProperty(ref currentMovie, value);
        }
        public IList<Movie> Movies { get; set; }
        public MockRepository()
        {
            Movies = new ObservableCollection<Movie>
            {
                new Movie()
                {
                    Title = "Zootopia",
                    ReleaseDate = "2016",
                    AudienceScore = 96,
                    TomatometerScore = 96,
                    PosterUrl = "img1.jpg",
                    BackdropUrl = "img2.jpg",
                    Info = "Determined to prove herself, Officer Judy Hopps, the first bunny on Zootopia's police force, jumps at the chance to crack her first case - even if it means partnering with scam-artist fox Nick Wilde to solve the mystery.",
                    Cast = new List<CastMember>()
                    {
                        new CastMember() { Name="Ginnifer Goodwin", Role="Judy Hopps (voice)", ImageUrl="img3.jpg"},
                        new CastMember() { Name="Jason Bateman", Role="Nick Wilde (voice)", ImageUrl="img4.jpg"},
                        new CastMember() { Name="Shakira", Role="Gazelle (voice)", ImageUrl="img5.jpg"},
                        new CastMember() { Name="Idris Elba", Role="Chief Bogo (voice)", ImageUrl="img6.jpg"},
                    }
                },
                 new Movie()
                 {
                    Title = "Mickey Mouse",
                    ReleaseDate = "2005",
                    AudienceScore = 99,
                    TomatometerScore = 77,
                    PosterUrl = "mickey_mouse_poster.jpg",
                    BackdropUrl = "mickey_mouse_backdrop.jpg",
                    Info = "Mickey Mouse Clubhouse, and was shown on Disney Junior as Mickey Calling Yehia Calling is an interactive American television series for children, shown from May 5, 2006 to November 6, 2016. This series is the first animated series on Disney TV targeting children ",
                    Cast = new List<CastMember>()
                    {
                        new CastMember() { Name="Jack Goodwin", Role="Judy Hopps (voice)", ImageUrl="jack.jpg"},
                        new CastMember() { Name="Jason Bateman", Role="Nick Wilde (voice)", ImageUrl="smile_white_man.jpg"},
                        new CastMember() { Name="Sheerin", Role="Gazelle (voice)", ImageUrl="smile_black_man.jpg"},
                        new CastMember() { Name="Elias sony", Role="Chief Bogo (voice)", ImageUrl="img4.jpg"},
                    }
                 },
                 new Movie()
                 {
                    Title = "The Seven Dwarfs",
                    ReleaseDate = "1938",
                    AudienceScore = 69,
                    TomatometerScore = 82,
                    PosterUrl = "the_seven_dwarfs_poster.jpg",
                    BackdropUrl = "the_seven_dwarfs_backdrop.jpg",
                    Info = "The Seven Dwarfs are a group of seven dwarfs that live in a tiny cottage and work in the nearby mines. Snow White happens upon their house after being told by the Huntsman to flee from the Queen's kingdom",
                    Cast = new List<CastMember>()
                    {
                        new CastMember() { Name="David Hand", Role="Judy Hopps (voice)", ImageUrl="indian_man2.jpg"},
                        new CastMember() { Name="William Cottrell", Role="Nick Wilde (voice)", ImageUrl="indian_man1.jpg"},
                        new CastMember() { Name="Sharpstein", Role="Gazelle (voice)", ImageUrl="smile_black_man.jpg"},
                        new CastMember() { Name="Larry Murray", Role="Chief Bogo (voice)", ImageUrl="red_hair_woman.jpg"},
                    }
                 }
            };
            CurrentMovie = Movies[0];
        }
        public Command ImageButton_RightCommand
        {
            get
            {
                return new Command(ImageButton_Right);
            }
        }
        private void ImageButton_Right()
        {
            _ = indexMovie + 1 == 3 ? indexMovie = 0 : indexMovie++;
            CurrentMovie = Movies[indexMovie];
        }
        public Command ImageButton_LeftCommand
        {
            get
            {
                return new Command(ImageButton_Left);
            }
        }
        private void ImageButton_Left()
        {
            _ = indexMovie - 1 == -1 ? indexMovie = 2 : indexMovie--;
            CurrentMovie = Movies[indexMovie];
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int AudienceScore { get; set; }
        public int TomatometerScore { get; set; }
        public string Info { get; set; }
        public List<CastMember> Cast { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
    }

    public class CastMember
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }
    }
}
