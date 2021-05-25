using PropertyGridTest.Data;
using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridTest.Editors
{
    /// <summary>
    /// Control для отметки иностранных языков
    /// </summary>
    public partial class ForeignLangsControl : UserControl
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fl">список языков для простановки отметок</param>
        public ForeignLangsControl(ForeignLangs fl)
        {
            InitializeComponent();

            _foreignLangs = fl;

            foreach (string lang in fl.ForeignLangsList)
            {
                CheckLanguage(lang);
            }
        }

        // отметить язык в CheckedListBox
        private void CheckLanguage(string lang)
        {
            int i = 0;
            foreach (object it in checkedListBox1.Items)
            {
                if (lang == it.ToString())
                {
                    checkedListBox1.SetItemChecked(i, true);
                    return;
                }
                i++;
            }
        }

        // Текущий список отмеченых языков
        private ForeignLangs _foreignLangs;

        /// <summary>
        /// Текущий список отмеченых языков
        /// </summary>
        public ForeignLangs Foreignlangs
        {
            get
            {
                // переформировать список согласно отмеченным языкам
                _foreignLangs.ForeignLangsList.Clear();
                foreach (object it in checkedListBox1.CheckedItems)
                {
                    _foreignLangs.ForeignLangsList.Add(it.ToString());
                }
                return _foreignLangs;
            }
            set { _foreignLangs = value; }
        }

        // закончить редактирование
        private void btnOK_Click(object sender, EventArgs e)
        {
            ((IWindowsFormsEditorService)Tag).CloseDropDown();
        }
    }
}
