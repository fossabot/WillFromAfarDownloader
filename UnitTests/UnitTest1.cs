﻿using System;
using System.Diagnostics;
using AcapellaDownloader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void CheckVoices()
        {
         
            Assert.That(true, Is.EqualTo(ParseAllVoices()));
        }

        public bool ParseAllVoices()
        {
            
            Voices.Load();
            for (int i = 0; i < Voices.VoiceList.Count; i++)
            {
                Voice voicelist = Voices.VoiceList[i];
                if (Utils.Parse("123", voicelist.VoiceFile) == "")
                {
                    TestContext.Progress.WriteLine($"[{i+1}/{Voices.VoiceList.Count}] {voicelist.Name} NOT PASSED");
                    return false;
                }
                else
                {
                    TestContext.Progress.WriteLine($"[{i+ 1}/{Voices.VoiceList.Count}]"+voicelist.Name + " PASSED");
                }
                
            }

            return true;
        }
    }
}
