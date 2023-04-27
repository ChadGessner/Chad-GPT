﻿using Chad_GPT_Models.DBModels;
using Chad_GPT_Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public ImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StringyConnections"));
        }
        public Image InsertImage(User user, Image image)
        {
            return new Image();
        }
    }
}
