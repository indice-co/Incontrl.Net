﻿using System;

namespace Incontrl.Sdk.Models
{
    public class ServiceInfo
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public bool Enabled { get; set; }
        public UiHint UiHint { get; set; }
        public dynamic Settings { get; set; }
        public object SettingsSchema { get; set; }
        public ServiceType Type { get; set; }
    }
}