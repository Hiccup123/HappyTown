using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

namespace NetWork
{
    public class ByteBuffer
    {
        MemoryStream stream = null;
        BinaryReader reader = null;
        BinaryWriter writer = null;

        public ByteBuffer()
        {
            stream = new MemoryStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }

        ~ByteBuffer()
        {
            stream.Dispose();
        }

        public ByteBuffer(byte[] data)
        {
            if(data != null)
            {
                stream = new MemoryStream(data);
                reader = new BinaryReader(stream);
            }
            else
            {
                stream = new MemoryStream();
                writer = new BinaryWriter(stream);
            }
        }

        public void Close()
        {
            if (writer != null) writer.Close();
            if (reader != null) reader.Close();

            stream.Close();
            writer = null;
            reader = null;
            stream = null;
        }
    }
}

