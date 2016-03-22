﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookmarkService.DAL;
using WebBookmarkService.Model;

namespace WebBookmarkBo.Model
{
    public class BizUserWebFolder
    {
        #region 属性


        /// <summary>
        /// 主键，自增
        /// </summary>
        public long UserWebFolderID { get; set; }

        /// <summary>
        /// 收藏夹名称
        /// </summary>
        public string WebFolderName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserInfoID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 对外是否可见
        /// </summary>
        public sbyte Visible { get; set; }

        /// <summary>
        /// 父收藏夹ID
        /// </summary>
        public long ParentWebfolderID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IntroContent { get; set; }


        public string IElementJSON { get; set; }

        public int IElementHashcode { get; set; }


        public List<BizBookmarkInfo> BizBookmarkInfoList { get; set; }

        public List<BizUserWebFolder> ChildrenFolderList { get; set;}



        #endregion


        public UserWebFolder ToModel()
        {

            return new UserWebFolder()
            {
                UserInfoID= UserInfoID,
                UserWebFolderID=UserWebFolderID,
                IntroContent = IntroContent,
                CreateTime=CreateTime,
                ParentWebfolderID = ParentWebfolderID,
                Visible = Visible,
                WebFolderName = WebFolderName,
                IElementJSON = IElementJSON,
                IElementHashcode = IElementHashcode,
            };

        } 

        public BizUserWebFolder (UserWebFolder dataInfo)
        {
            UserInfoID = dataInfo.UserInfoID;
            UserWebFolderID = dataInfo.UserWebFolderID;
            IntroContent = dataInfo.IntroContent;
            CreateTime = dataInfo.CreateTime;
            ParentWebfolderID = dataInfo.ParentWebfolderID;
            Visible = dataInfo.Visible;
            WebFolderName = dataInfo.WebFolderName;
            IElementJSON = dataInfo.IElementJSON;
            IElementHashcode = dataInfo.IElementHashcode;
        }

        public BizUserWebFolder()
        {

        }

        public void Save ()
        {
            if(UserWebFolderID !=0)
            {
                new UserWebFolderDAL().Update(ToModel());

            }else
            {
                new UserWebFolderDAL().Add(ToModel());
            }
        }


        public static List<BizUserWebFolder> LoadAllByUID(long uid)
        {
            List<BizUserWebFolder> list = new List<BizUserWebFolder>();
            var lstModel = new UserWebFolderDAL().GetByUID(uid);
            if(lstModel!=null)
            {
                list.AddRange(lstModel.Select(model=>new BizUserWebFolder(model)));
            }
            return list;
        }



    }
}
