using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace TicTacToe {
    public partial class MainPage : PhoneApplicationPage {
        public static string turn = "X";
        public static Dictionary<string, TTT_Box> Boxes = new Dictionary<string, TTT_Box> {
            { "UL", new TTT_Box_Corner() }, { "UC", new TTT_Box_HoriEdge() }, { "UR", new TTT_Box_Corner() },
            { "ML", new TTT_Box_VertEdge() }, { "MC", new TTT_Box_Center() }, { "MR", new TTT_Box_VertEdge() },
            { "DL", new TTT_Box_Corner() }, { "DC", new TTT_Box_HoriEdge() }, { "DR", new TTT_Box_Corner() },
        };

        // Constructor
        public MainPage() {
            InitializeComponent();
            //Define the TTT Grid/Connections
            Boxes["UL"].Horizontal = Boxes["UC"]; Boxes["UL"].Vertical = Boxes["ML"]; Boxes["UL"].Diagnol = Boxes["MC"];
            Boxes["UC"].Left = Boxes["UL"]; Boxes["UC"].Right = Boxes["UR"]; Boxes["UC"].Vertical = Boxes["MC"];
            Boxes["UR"].Horizontal = Boxes["UC"]; Boxes["UR"].Vertical = Boxes["MR"]; Boxes["UR"].Diagnol = Boxes["MC"];
            Boxes["ML"].Up = Boxes["UL"]; Boxes["ML"].Down = Boxes["DL"]; Boxes["ML"].Horizontal = Boxes["MC"];
            Boxes["MC"].Up = Boxes["UC"]; Boxes["MC"].Down = Boxes["DC"]; Boxes["MC"].Left = Boxes["ML"]; Boxes["MC"].Right = Boxes["MR"]; Boxes["MC"].UpLeft = Boxes["UL"]; Boxes["MC"].UpRight = Boxes["UR"]; Boxes["MC"].DownLeft = Boxes["DL"]; Boxes["MC"].DownRight = Boxes["DR"];
            Boxes["MR"].Up = Boxes["UR"]; Boxes["MR"].Down = Boxes["DR"]; Boxes["MR"].Horizontal = Boxes["MC"];
            Boxes["DL"].Horizontal = Boxes["DC"]; Boxes["DL"].Vertical = Boxes["ML"]; Boxes["DL"].Diagnol = Boxes["MC"];
            Boxes["DC"].Left = Boxes["DL"]; Boxes["DC"].Right = Boxes["DR"]; Boxes["DC"].Vertical = Boxes["MC"];
            Boxes["DR"].Horizontal = Boxes["DC"]; Boxes["DR"].Vertical = Boxes["MR"]; Boxes["DR"].Diagnol = Boxes["MC"];
            
        }

        public class TTT_Box {
            public string mark;
            public TTT_Box Up; public TTT_Box Down; public TTT_Box Left;
            public TTT_Box Right; public TTT_Box UpRight; public TTT_Box UpLeft;
            public TTT_Box DownRight; public TTT_Box DownLeft;
            public TTT_Box Diagnol; public TTT_Box Horizontal; public TTT_Box Vertical;

            public string get_mark() {
                return mark;
            }

            public virtual Boolean check_TTT() {
                return false;
            }

            public Boolean set_mark() {
                if (mark != null) {
                    return false;
                } else {
                    mark = turn;
                    if (turn.Equals("X")) {
                        turn = "O";
                    } else {
                        turn = "X";
                    }
                    return true;
                }

            }

            public Boolean check_boxes(TTT_Box box1, TTT_Box box2) {
                try {
                    if (mark == box1.mark && mark == box2.mark) {
                        return true;
                    } else {
                        return false;
                    }
                } catch {
                    return false;
                }
            }
        }

        public class TTT_Box_HoriEdge : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Left, this.Right) || check_boxes(this.Vertical, this.Vertical.Vertical)) {
                    return true;
                }
                return false;
            }
        }

        public class TTT_Box_VertEdge : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Up, this.Down) || check_boxes(this.Horizontal, this.Horizontal.Horizontal)) {
                    return true;
                }
                return false;
            }
        }

        public class TTT_Box_Corner : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Horizontal, this.Horizontal.Horizontal) || check_boxes(this.Vertical, this.Vertical.Vertical) || check_boxes(this.Diagnol, this.Diagnol.Diagnol)) {
                    return true;
                }
                return false;
            }
        }

        public class TTT_Box_Center : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Left, this.Right) || check_boxes(this.Down, this.Up) || check_boxes(this.UpLeft, this.DownRight) || check_boxes(this.UpRight, this.DownLeft)) {
                    return true;
                }
                return false;
            }

        }

        private void TTT_Move(object sender, RoutedEventArgs e) {
            Button clicked = (Button)sender;
            if (Boxes[clicked.Name].set_mark()) {
                clicked.Content = turn;
                if (Boxes[clicked.Name].check_TTT()) {
                    winner_popup.IsOpen = true;
                }
            }
        }

        private void winner_popup_btn(object sender, RoutedEventArgs e) {
            winner_popup.IsOpen = false;
        }
    }
}