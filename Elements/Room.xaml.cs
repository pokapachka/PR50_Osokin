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
using ПР50_Осокин.Context;

namespace ПР50_Осокин.Elements
{
    /// <summary>
    /// Логика взаимодействия для Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        public Room(int Room)
        {
            InitializeComponent();
            NameRoom.Content += Room.ToString();
            LoadOwner(Room);
        }
        public void LoadOwner(int Room)
        {
            List<OwnerContext> roomOwners = OwnerContext.AllOwners().FindAll(x => x.NumberRoom == Room);
            foreach (var roomOwner in roomOwners) 
                parent.Children.Add(new Elements.Owner(roomOwner));
        }
    }
}
