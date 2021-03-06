using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lurchsoft.FileData.Reading
{
    internal class EmbeddedTextFile : ITextFile
    {
        private readonly FileLines lines;

        public EmbeddedTextFile(string fileName)
        {
            lines = new FileLines(fileName);
        }

        public IEnumerable<string> ReadLines()
        {
            return lines;
        }

        public override string ToString()
        {
            return lines.ToString();
        }

        private class FileLines : IEnumerable<string>
        {
            private readonly string fileName;

            public FileLines(string fileName)
            {
                this.fileName = fileName;
            }

            public IEnumerator<string> GetEnumerator()
            {
                var stream = EmbeddedResource.Open(fileName);
                return new LinesEnumerator(stream);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString()
            {
                return fileName;
            }
        }

        private class LinesEnumerator : IEnumerator<string>
        {
            private readonly Stream stream;
            private TextReader reader;

            public LinesEnumerator(Stream stream)
            {
                this.stream = stream;
                reader = new StreamReader(stream);
            }

            public string Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; } 
            }

            public void Dispose()
            {
                reader.Dispose();
                stream.Dispose();
            }

            public bool MoveNext()
            {
                return (Current = reader.ReadLine()) != null;
            }

            public void Reset()
            {
                stream.Seek(0L, SeekOrigin.Begin);
                Current = null;
                reader.Dispose();
                reader = new StreamReader(stream);
            }
        }
    }
}
