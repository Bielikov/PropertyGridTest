using PropertyGridTest.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PropertyGridTest.Editors
{
    /// <summary>
    /// Форма для редактирования ip-адреса
    /// </summary>
    public partial class IPAddressEditorForm : Form
    {
        public IPAddressEditorForm(IPAddress ip)
        {
            InitializeComponent();

            IP = ip;
        }

        /// <summary>
        /// Преобразование представления ip в MaskedTextBox
        /// и в нормальном виде
        /// </summary>
        public IPAddress IP
        {
            // MaskedTextBox добивает короткие части ip пробелами до 3-х знаков
            // эти пробелы нужно удалять
            get { return new IPAddress(IPmaskedTextBox.Text.Replace(" ", "")); }

            // а здесь наоборот - надо выровнять пробелами
            set
            {
                // если части IP короче 3 знаков, MaskedTextBox их слепляет :(
                // надо их при необходимости подравнять пробелами
                // чтоб легли в маску
                Regex r = new Regex(@"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$");
                Match m = r.Match(value.IP);
                string ip4maskedit = "";
                bool firstgroup = true;
                foreach (Group g in m.Groups)
                {
                    if (firstgroup)
                    {
                        firstgroup = false;
                        continue;
                    }

                    string s = g.ToString();
                    while (s.Length < 3)
                        s += " ";

                    ip4maskedit += s;
                }

                IPmaskedTextBox.Text = ip4maskedit;
            }
        }
    }
}