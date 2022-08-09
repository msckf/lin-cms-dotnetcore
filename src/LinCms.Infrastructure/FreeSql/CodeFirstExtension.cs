﻿using System;
using System.Collections.Generic;
using FreeSql;
using LinCms.Common;
using LinCms.Data.Enums;
using LinCms.Entities;
using LinCms.Entities.Base;

namespace LinCms.FreeSql
{
    public static class CodeFirstExtension
    {

        public static ICodeFirst SeedData(this ICodeFirst @this)
        {           
            @this.Entity<LinGroup>(e =>
            {
                e.HasData(new List<LinGroup>()
                    {
                        new(LinGroup.Admin,"系统管理员",true),
                        new(LinGroup.CmsAdmin,"CMS管理员",true),
                        new(LinGroup.User,"普通用户",true)
                    });
            })
                .Entity<LinUser>(e =>
                {
                    e.HasData(new List<LinUser>()
                    {
                        new()
                        {
                            Nickname="系统管理员",
                            Username="admin",
                            Active=UserActive.Active,
                            CreateTime=DateTime.Now,
                            IsDeleted=false,
                            Salt="9fd248c8-e9da-412f-bad9-aa5f7f1d7b80",
                            LinUserIdentitys=new List<LinUserIdentity>()
                            {
                               new(LinUserIdentity.Password,"admin","IWxIlqMAE3SU3JTogdDAJw==",DateTime.Now) //密码是 123qwe
                            },
                            LinUserGroups=new List<LinUserGroup>()
                            {
                                new(1,LinConsts.Group.Admin)
                            },
                        },
                        new()
                         {
                             Nickname="CMS管理员",
                             Username="CmsAdmin",
                             Active=UserActive.Active,
                             CreateTime=DateTime.Now,
                             IsDeleted=false,
                             Salt="9fd248c8-e9da-412f-bad9-aa5f7f1d7b80",
                             LinUserIdentitys=new List<LinUserIdentity>()
                             {
                                 new(LinUserIdentity.Password,"CmsAdmin","IWxIlqMAE3SU3JTogdDAJw==",DateTime.Now)
                             },
                             LinUserGroups=new List<LinUserGroup>()
                             {
                                 new(2,LinConsts.Group.CmsAdmin)
                             },
                         }
                    });
                })
                .Entity<BaseType>(e =>
                {
                    e.HasData(new List<BaseType>()
                    {
                        new("Article.Type","随笔类型",1)
                        {
                            CreateTime=DateTime.Now,IsDeleted=false,CreateUserId = 1,
                            BaseItems=new List<BaseItem>()
                            {
                                new("0","原创",1,1,true){CreateUserId = 1,CreateTime=DateTime.Now,IsDeleted=false},
                                new("1","转载",2,1,true){CreateUserId = 1,CreateTime=DateTime.Now,IsDeleted=false},
                                new("2","翻译",3,1,true){CreateUserId = 1,CreateTime=DateTime.Now,IsDeleted=false}
                            }
                        },
                         new("Sex","性别",2)
                         {
                             CreateTime=DateTime.Now,IsDeleted=false,CreateUserId = 1,
                             BaseItems=new List<BaseItem>()
                             {
                                 new("0","男",1,2,true){CreateTime=DateTime.Now,IsDeleted=false},
                                 new("1","女",2,2,true){CreateTime=DateTime.Now,IsDeleted=false},
                                 new("2","保密",3,2,true){CreateTime=DateTime.Now,IsDeleted=false}
                             }
                         },
                    });
                })
                ;
            return @this;
        }
    }
}
