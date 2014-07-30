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
        public static int num_turns = 0;
        public static Dictionary<string, TTT_Box> Boxes = new Dictionary<string, TTT_Box> {
            { "UL", new TTT_Box_Corner() }, { "UC", new TTT_Box_HoriEdge() }, { "UR", new TTT_Box_Corner() },
            { "ML", new TTT_Box_VertEdge() }, { "MC", new TTT_Box_Center() }, { "MR", new TTT_Box_VertEdge() },
            { "DL", new TTT_Box_Corner() }, { "DC", new TTT_Box_HoriEdge() }, { "DR", new TTT_Box_Corner() },
        };

        // Constructor
        public MainPage() {
            InitializeComponent();
            //Define the TTT Grid/Connections
            Boxes["UL"].Horizontal = new TTT_Box[] {Boxes["UC"], Boxes["UL"]}; Boxes["UL"].Vertical = new TTT_Box[] {Boxes["ML"], Boxes["DL"]}; Boxes["UL"].Diagnol = new TTT_Box[] {Boxes["MC"], Boxes["DR"]};
            Boxes["UC"].Horizontal = new TTT_Box[] {Boxes["UL"], Boxes["UR"]}; Boxes["UC"].Vertical = new TTT_Box[] {Boxes["MC"], Boxes["DC"]};
            Boxes["UR"].Horizontal = new TTT_Box[] {Boxes["UC"], Boxes["UL"]}; Boxes["UR"].Vertical = new TTT_Box[] {Boxes["MR"], Boxes["DR"]}; Boxes["UR"].Diagnol = new TTT_Box[] {Boxes["MC"], Boxes["DL"]};
            Boxes["ML"].Vertical = new TTT_Box[] {Boxes["UL"], Boxes["DL"]}; Boxes["ML"].Horizontal = new TTT_Box[] {Boxes["MC"], Boxes["MR"]};
            Boxes["MC"].Vertical = new TTT_Box[] {Boxes["UC"], Boxes["MC"]}; Boxes["MC"].Horizontal = new TTT_Box[] {Boxes["ML"], Boxes["MC"]}; Boxes["MC"].Diagnol = new TTT_Box[] {Boxes["UL"], Boxes["DR"]}; Boxes["MC"].Diagnol2 = new TTT_Box[] {Boxes["UR"], Boxes["DL"]};
            Boxes["MR"].Vertical = new TTT_Box[] {Boxes["UR"], Boxes["MR"]}; Boxes["MR"].Horizontal = new TTT_Box[] {Boxes["MC"], Boxes["ML"]};
            Boxes["DL"].Horizontal = new TTT_Box[] {Boxes["DC"], Boxes["DR"]}; Boxes["DL"].Vertical = new TTT_Box[] {Boxes["ML"], Boxes["UL"]}; Boxes["DL"].Diagnol = new TTT_Box[] {Boxes["MC"], Boxes["UR"]};
            Boxes["DC"].Horizontal = new TTT_Box[] {Boxes["DL"], Boxes["DR"]}; Boxes["DC"].Vertical = new TTT_Box[] {Boxes["MC"], Boxes["UC"]};
            Boxes["DR"].Horizontal = new TTT_Box[] {Boxes["DC"], Boxes["DL"]}; Boxes["DR"].Vertical = new TTT_Box[] {Boxes["MR"], Boxes["UR"]}; Boxes["DR"].Diagnol = new TTT_Box[] {Boxes["MC"], Boxes["UL"]};
        }

        public class TTT_Box {
            public string mark;
            public TTT_Box[] Diagnol; public TTT_Box[] Horizontal; public TTT_Box[] Vertical; public TTT_Box[] Diagnol2;

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
                    num_turns++;
                    return true;
                }

            }

            public Boolean check_boxes(TTT_Box box1, TTT_Box box2) {
                try {
                    if (mark == box1.mark && mark == box2.mark) {
                        return true;
                    } else {
                        if (num_turns == 9) {

                        }
                        return false;
                    }
                } catch {
                    return false;
                }
            }
        }

        public class TTT_Box_HoriEdge : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Horizontal[0], this.Horizontal[1]) || check_boxes(this.Vertical[0], this.Vertical[1])) {
                    return true;
                }
                return false;
            }
        }

        public class TTT_Box_VertEdge : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Vertical[0], this.Vertical[1]) || check_boxes(this.Horizontal[0], this.Horizontal[1])) {
                    return true;
                }
                return false;
            }
        }

        public class TTT_Box_Corner : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Horizontal[0], this.Horizontal[1]) || check_boxes(this.Vertical[0], this.Vertical[1]) || check_boxes(this.Diagnol[0], this.Diagnol[1])) {
                    return true;
                }
                return false;
            }
        }

        public class TTT_Box_Center : TTT_Box {
            public override Boolean check_TTT() {
                if (check_boxes(this.Horizontal[0], this.Horizontal[1]) || check_boxes(this.Vertical[0], this.Vertical[1]) || check_boxes(this.Diagnol[0], this.Diagnol[1]) || check_boxes(this.Diagnol2[0], this.Diagnol[1])) {
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
                    if (turn == "X") {
                        ttt_popup_text.Text = "Winnner is X";
                    } else {
                        ttt_popup_text.Text = "Winner is O";
                    }
                    ttt_popup.IsOpen = true;
                }
                else if (num_turns == 9) {
                    ttt_popup_text.Text = "Draw";
                    ttt_popup.IsOpen = true;
                }
            }
        }

        private void ttt_popup_btn(object sender, RoutedEventArgs e) {
            UL.Content = ""; UC.Content = ""; UR.Content = "";
            ML.Content = ""; MC.Content = ""; MR.Content = "";
            DL.Content = ""; DC.Content = ""; DR.Content = "";
            foreach (KeyValuePair <string, TTT_Box> box in Boxes) {
                box.Value.mark = null;
            }
            num_turns = 0;
            ttt_popup.IsOpen = false;
        }
    }
}