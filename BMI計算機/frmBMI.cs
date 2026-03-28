using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
     
        public frmBMI()
        {
            InitializeComponent();         
        }
        private void lblHeight_Click(object sender, EventArgs e)
        {

        }

        private void lblWeight_Click(object sender, EventArgs e)
        {

        }

        private void btnRUN_Click(object sender, EventArgs e)
        {        
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);

            if (!isHeightValid || !isWeightValid)
            {
                MessageBox.Show("請輸入有效的數字。", "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            height /= 100.0;
            double bmi = weight / (height * height);

            string[] strResultList =
            {
        "體重過輕", "健康體位", "體位過重",
        "輕度肥胖", "中度肥胖", "重度肥胖"
    };

    Color[] colorList =
    {
        ColorTranslator.FromHtml("#81D4FA"), // [0] 體重過輕 (柔和粉藍)
        ColorTranslator.FromHtml("#A5D6A7"), // [1] 健康體位 (柔和粉綠)
        ColorTranslator.FromHtml("#FFE082"), // [2] 體位過重 (柔和粉黃)
        ColorTranslator.FromHtml("#FFB74D"), // [3] 輕度肥胖 (柔和橘色)
        ColorTranslator.FromHtml("#EF5350"), // [4] 中度肥胖 (柔和紅色)
        ColorTranslator.FromHtml("#AB47BC")  // [5] 重度肥胖 (柔和紫色)
    };

            int resultIndex;

            if (bmi < 18.5)
            {
                resultIndex = 0;
                picResult.Image = Properties.Resources.eso;
            }
            else if (bmi < 24)
            {
                resultIndex = 1;
                picResult.Image = Properties.Resources.good;
            }
            else if (bmi < 27)
            {
                resultIndex = 2;
                picResult.Image = Properties.Resources.fat;
            }
            else if (bmi < 30)
            {
                resultIndex = 3;
                picResult.Image = Properties.Resources.fat;
            }
            else if (bmi < 35)
            {
                resultIndex = 4;
                picResult.Image = Properties.Resources.fat;
            }
            else
            {
                resultIndex = 5;
                picResult.Image = Properties.Resources.fat;
            }
                string strResult = strResultList[resultIndex];
            Color colorResult = colorList[resultIndex];

            lblResult.Text = $"{bmi:F2} ({strResult})";
            lblResult.BackColor = colorResult;

            MessageBox.Show("BMI 計算完成！", "計算成功",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHeight.Clear();
            txtWeight.Clear();

            lblResult.BackColor = SystemColors.Control; 

            txtHeight.Focus();
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; 
            }
            // 確保小數點只能輸入一次
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }

    
}
