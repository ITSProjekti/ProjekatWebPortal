using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.ViewModels
{
    public class ForumViewModel
    {
        public IEnumerable<Forum_Post> postsModel { get; set; }
        public IEnumerable<AspNetUser> UsersDetails { get; set; }

    }
}