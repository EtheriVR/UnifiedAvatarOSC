using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAvatarOSCBase;

namespace UnifiedAvatarOSC
{
    internal class LogManager
    {

        RichTextBox textBox;

        public LogManager(RichTextBox textBox)
        {
            this.textBox = textBox;
        } 

        public void Dequeue()
        {
            Action msg = () =>
            {
                string message;
                while (Log.Instance.MessageQueue.TryDequeue(out message))
                {
                    textBox.AppendText("[" + DateTime.Now.ToShortTimeString() + "]", Color.Red);
                    textBox.AppendText("[MSG] ", Color.Blue);
                    textBox.AppendText(message);
                    textBox.AppendText(Environment.NewLine);
                }
            };

            Action send = () =>
            {
                SendLog log;
                while (Log.Instance.OscSendQueue.TryDequeue(out log))
                {
                    textBox.AppendText("[" + DateTime.Now.ToShortTimeString() + "]");
                    textBox.AppendText("[SEND] ", Color.Green);
                    textBox.AppendText("ADDRESS: ", Color.LightBlue);
                    textBox.AppendText(log.address + "\t");
                    textBox.AppendText("DATA: ", Color.LightGreen);
                    textBox.AppendText(log.data + "\t");
                    textBox.AppendText("MODULE: ", Color.MediumPurple);
                    textBox.AppendText(log.module + "\t");
                    textBox.AppendText(Environment.NewLine);
                }
            };

            Parallel.Invoke(msg);
            Parallel.Invoke(send);

        }
    }
}
