using System;
using System.Collections.Concurrent;

namespace Blackbox.Client
{
    public class BufferedVideoDataQueue : ConcurrentQueue<byte[]>
    {
        /// <summary>
        /// Holds an array of bytes left over from the previous dequeue.
        /// </summary>
        private byte[] chunk = null;

        /// <summary>
        /// Removes item(s) from the queue and copies them into the buffer until 
        /// either the buffer is full or the queue is emptied.
        /// </summary>
        /// <param name="buffer">Byte array to copy data into.</param>
        /// <returns>The number of bytes copied into the buffer. Could be less 
        /// than the size of the buffer depending on the number of elements in the 
        /// queue.</returns>
        public int Dequeue(byte[] buffer)
        {
            int i = 0;

            while (i < buffer.Length && (chunk is not null || base.TryDequeue(out chunk)))
            {
                if (i + chunk.Length > buffer.Length)
                {
                    int size = buffer.Length - i;
                    new ArraySegment<byte>(chunk, 0, size).CopyTo(buffer, i);
                    chunk = new ArraySegment<byte>(chunk, size, chunk.Length - size).ToArray();
                }
                else
                {
                    chunk.CopyTo(buffer, i);
                    i += chunk.Length;
                    chunk = null;
                }
            }

            return i;
        }
    }
}
