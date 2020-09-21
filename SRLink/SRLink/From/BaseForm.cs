﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Model;
using Kit.Utils;
using Kit.Win;
using SRLink.Service;
using SRLink.Service.Impl;

namespace SRLink.From
{
    public partial class BaseForm : Form
    {
        public readonly ILoggerService Logger;
        public readonly IConfigService ConfigService;
        public static Config Config;
        public BaseForm()
        {
            Logger = new LoggerService();
            ConfigService = new ConfigService();
            InitializeComponent();
        }
    }
}
