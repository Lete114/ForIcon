using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForIcon
{
    public partial class ForIcon : Form
    {
        public ForIcon()
        {
            InitializeComponent();
        }


        // 拖入文件执行
        private void ForIcon_DragEnter(object sender, DragEventArgs e){
                e.Effect = DragDropEffects.All;
        }

        // 拖入文件松开鼠标后执行
        private void ForIcon_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖入的文件路径
            string File_Path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            // 判断后缀名
            if (System.IO.Path.GetExtension(File_Path) != ".exe") {
                MessageBox.Show("当前文件不是EXE文件~", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                SaveFileDialog sfd = new SaveFileDialog(); // 保存文件对话框
                sfd.Filter = "|*.ico"; // 后缀名
                if (sfd.ShowDialog() == DialogResult.OK) { // 判断是否点击保存(未填写文件名则无效)
                    // 获取拖入文件的图标
                    Image img = Icon.ExtractAssociatedIcon(File_Path).ToBitmap();
                    img.Save(sfd.FileName);
                } 
            }
        }
    }
}
