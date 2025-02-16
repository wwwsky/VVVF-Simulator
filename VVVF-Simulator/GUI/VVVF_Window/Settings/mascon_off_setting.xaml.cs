﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using VVVF_Simulator.Yaml.VVVF_Sound;
using static VVVF_Simulator.Yaml.VVVF_Sound.Yaml_VVVF_Sound_Data;
using static VVVF_Simulator.Yaml.VVVF_Sound.Yaml_VVVF_Sound_Data.Yaml_Mascon_Data;
using static VVVF_Simulator.Yaml.VVVF_Sound.Yaml_VVVF_Sound_Data.Yaml_Mascon_Data.Yaml_Mascon_Data_On_Off;

namespace VVVF_Simulator.VVVF_Window.Settings
{
    /// <summary>
    /// mascon_off_setting.xaml の相互作用ロジック
    /// </summary>
    public partial class mascon_off_setting : Page
    {
        public mascon_off_setting()
        {
            InitializeComponent();
            Yaml_VVVF_Sound_Data ysd = Yaml_VVVF_Manage.current_data;

            Accel_Mascon_On_Freq_Goto.Text = ysd.mascon_data.accelerating.on.control_freq_go_to.ToString();
            Accel_Mascon_On_Rate.Text = ysd.mascon_data.accelerating.on.freq_per_sec.ToString();
            Accel_Mascon_Off_Freq_Goto.Text = ysd.mascon_data.accelerating.off.control_freq_go_to.ToString();
            Accel_Mascon_Off_Rate.Text = ysd.mascon_data.accelerating.off.freq_per_sec.ToString();

            Brake_Mascon_On_Freq_Goto.Text = ysd.mascon_data.braking.on.control_freq_go_to.ToString();
            Brake_Mascon_On_Rate.Text = ysd.mascon_data.braking.on.freq_per_sec.ToString();
            Brake_Mascon_Off_Rate.Text = ysd.mascon_data.braking.off.freq_per_sec.ToString();
            Brake_Mascon_Off_Freq_Goto.Text = ysd.mascon_data.braking.off.control_freq_go_to.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            Object? tag = tb.Tag;
            if (tag == null) return;
            String? tag_name = tag.ToString();
            if (tag_name == null) return;
            String[] name_data = tag_name.Split("-");

            //Accel_On_Freq
            Yaml_Mascon_Data ymd = Yaml_VVVF_Manage.current_data.mascon_data;
            Yaml_Mascon_Data_On_Off ymdoo;
            Yaml_Mascon_Data_Single ymds;

            if (name_data[0].Equals("Accel")) ymdoo = ymd.accelerating;
            else ymdoo = ymd.braking;

            if (name_data[1].Equals("On")) ymds = ymdoo.on;
            else ymds = ymdoo.off;

            if (name_data[2].Equals("Freq"))
            {
                try
                {
                    double d = Double.Parse(tb.Text);
                    tb.Background = new BrushConverter().ConvertFrom("#FFFFFFFF") as Brush;
                    ymds.control_freq_go_to = d;
                }
                catch
                {
                    tb.Background = new BrushConverter().ConvertFrom("#FFfed0d0") as Brush;
                }
            }
            else
            {
                try
                {
                    double d = Double.Parse(tb.Text);
                    tb.Background = new BrushConverter().ConvertFrom("#FFFFFFFF") as Brush;
                    ymds.freq_per_sec = d;
                }
                catch
                {
                    tb.Background = new BrushConverter().ConvertFrom("#FFfed0d0") as Brush;
                }
            }

        }
    }
}
