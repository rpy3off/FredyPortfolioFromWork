﻿namespace Shared.Models
{
    public class UploadedImage
    {
        public string NewImageFileExtension { get; set; }

        // Base 64 is string that represents binary
        public string NewImageBase64Content { get; set; }
        public string OldImagePath { get; set; }

    }
}
