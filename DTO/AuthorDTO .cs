﻿using System.Diagnostics.CodeAnalysis;

namespace Book_API.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Biographpy { get; set; }
        public byte[] Image { get; set; }

    }
}
