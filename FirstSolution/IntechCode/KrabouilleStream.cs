using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntechCode
{
    public class KrabouilleStream : Stream
    {
        readonly Stream _inner;

        public KrabouilleStream( Stream inner )
        {
            if (inner == null) throw new ArgumentNullException(nameof(inner));
            _inner = inner;
        }

        public override bool CanRead => _inner.CanRead;

        public override bool CanSeek => _inner.CanSeek;

        public override bool CanWrite => _inner.CanWrite;

        public override long Length => _inner.Length;

        public override long Position
        {
            get => _inner.Position;
            set => _inner.Position = value;
        }

        public override void Flush() => _inner.Flush();

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _inner.Read(buffer, offset, count);
        }

        /// <summary>
        /// Basic, standard implementation that relies on <see cref="Position"/> do actually
        /// seek in this sream. Of course <see cref="CanSeek"/> must be true otherwise an exception 
        /// is thrown.
        /// </summary>
        /// <param name="offset">Offset (in bytes) from <paramref name="origin"/>.</param>
        /// <param name="origin">One of the <see cref="SeekOrigin"/> value.</param>
        /// <returns>The new <see cref="Position"/>.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (!CanSeek) throw new InvalidOperationException();
            switch(origin)
            {
                case SeekOrigin.Begin: Position = offset; break;
                case SeekOrigin.End: Position = Length - offset; break;
                case SeekOrigin.Current: Position += offset; break;
            }
            return Position;
        }

        public override void SetLength(long value) => _inner.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count)
        {
            _inner.Write(buffer, offset, count);
        }
    }
}
