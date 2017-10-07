using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocLibrary
{
    using System.IO;

    public class FileUtil
    {
        public bool HasDifferences(DirectoryInfo left, DirectoryInfo right)
        {
            if (left == null)
            {
                throw new ArgumentException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            var relativeDirectories = new List<string>();
            var missingDirectories = new List<DirectoryInfo>();

            foreach (var directory in left.GetDirectories())
            {
                relativeDirectories.Add(MakeRelative(directory));
            }

            foreach (var directory in right.GetDirectories())
            {
                var rightDir = MakeRelative(directory);

                if (relativeDirectories.Contains(rightDir))
                {
                    relativeDirectories.Remove(rightDir);
                }
                else
                {
                    missingDirectories.Add(directory);
                }
            }


            var filesLeft = left.GetFiles().ToList();
            foreach (var directory in left.GetDirectories())
            {
                foreach (var file in directory.GetFiles())
                {
                    filesLeft.Add(file);
                }
            }

            var filesRight = right.GetFiles().ToList();
            foreach (var directory in right.GetDirectories())
            {
                foreach (var file in directory.GetFiles())
                {
                    filesRight.Add(file);
                }
            }

            var missingFiles = new List<FileInfo>();
            foreach (var fileRight in filesRight)
            {
                if (!filesLeft.Contains(fileRight))
                {
                    missingFiles.Add(fileRight);
                }
            }

            foreach (var fileLeft in filesLeft)
            {
                if (!filesRight.Contains(fileLeft))
                {
                    missingFiles.Add(fileLeft);
                }
            }

            var missingFileCopy = new List<FileInfo>(missingFiles);
            foreach (var missingFile in missingFileCopy)
            {
                var extenstion = missingFile.Extension;

                switch (extenstion)
                {
                    case "tmp":
                    case "temp":
                        missingFiles.Remove(missingFile);
                        break;
                }
            }

            return missingDirectories.Count > 0 || missingFiles.Count > 0 ;
        }

        private string MakeRelative(DirectoryInfo directory)
        {
            return directory.FullName;
        }
    }
}
