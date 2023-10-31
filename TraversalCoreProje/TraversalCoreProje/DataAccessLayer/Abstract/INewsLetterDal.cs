﻿using EntityLayer.Concreate; // NewsLetter sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface INewsLetterDal:IGenericDal<NewsLetter>
    {
    }
}
