using ModelLibrary.Enumerate;
using ModelLibrary.Services;
using MvvmCommonLibrary.Behavior;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BlankCoreApp1.Services
{
    public class ContentViewService : IContentViewService
    {
        public ContentViewService()
        {
        }

        public Size GetContentSize(string key)
        {
            if (!ContentSizeRegister.RegistElementSize.ContainsKey(key))
            {
                throw new ArgumentException("キー値が存在しません。", key);
            }
            return ContentSizeRegister.RegistElementSize[key];
        }

        public Dictionary<ContentViewType, ContentControl> Contents { get; } = new Dictionary<ContentViewType, ContentControl>();

        public void RegisterWindowContent(ContentViewType contentViewType, ContentControl contentControl)
        {
            if (Contents.ContainsKey(contentViewType))
            {
                throw new ArgumentException("キー値が重複しています。", contentViewType.ToString());
            }
            Contents.Add(contentViewType, contentControl);
        }

        public ContentControl GetWindowContent(ContentViewType contentViewType)
        {
            if (!Contents.ContainsKey(contentViewType))
            {
                throw new ArgumentException("キー値が存在しません。", contentViewType.ToString());
            }
            return Contents[contentViewType];
        }
    }
}
