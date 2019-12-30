using System;
using System.Collections.Generic;
using System.Text;

namespace WebFileSystemCore
{
    public class Permissions
    {
        [Flags]
        public enum Permission
        {
            No = 0,
            Execute = 1,
            Write = 2,
            Read = 4
        }

        public Permission Owner { get; } = Permission.No;
        public Permission Group { get; } = Permission.No;
        public Permission Other { get; } = Permission.No;

        public Permissions() : this(777)
        {

        }

        public Permissions(string access)
        {
            if (string.IsNullOrEmpty(access) || access.Length != 9) { throw new ArgumentOutOfRangeException(); }
            var len = access.Length;
            Owner = StringToPermission(access.Substring(len - 9, 3));
            Group = StringToPermission(access.Substring(len - 6, 3));
            Other = StringToPermission(access.Substring(len - 3, 3));
        }
        public Permissions(int access)
        {
            if (access > 777 || access < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Owner = (Permission)(access / 100);
            Group = (Permission)(access % 100 / 10);
            Other = (Permission)(access % 10);
        }
        public Permissions(
            Permission owner = Permission.Read | Permission.Write | Permission.Execute,
            Permission group = Permission.Read | Permission.Write | Permission.Execute,
            Permission other = Permission.Read | Permission.Write | Permission.Execute)
        {
            Owner = owner;
            Group = group;
            Other = other;
        }

        public override string ToString()
        {
            return PermissionToString(Owner) + PermissionToString(Group) + PermissionToString(Other);
        }

        public override bool Equals(object obj)
        {
            if (obj is Permissions access)
            {
                return access.Owner == Owner && access.Group == Group && access.Other == Other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int ToInt()
        {
            return (int)Owner * 100 + (int)Owner * 10 + (int)Owner * 1;
        }

        public static Permission StringToPermission(string access)
        {
            if (string.IsNullOrEmpty(access) || access.Length != 3) { throw new ArgumentOutOfRangeException(); }
            var a = access.ToLower();
            var fileAccess = Permission.No;
            if (a.IndexOf(Read) > -1) { fileAccess |= Permission.Read; }
            if (a.IndexOf(Write) > -1) { fileAccess |= Permission.Write; }
            if (a.IndexOf(Execute) > -1) { fileAccess |= Permission.Execute; }
            return fileAccess;
        }

        public static string PermissionToString(Permission per)
        {
            var i = (int)per;
            switch (i)
            {
                case 0:
                    return N;
                case 1:
                    return E;
                case 2:
                    return W;
                case 3:
                    return WE;
                case 4:
                    return R;
                case 5:
                    return RE;
                case 6:
                    return RW;
                case 7:
                    return RWE;
                default:
                    throw new Exception();
            }
        }


        /// <summary>
        /// r
        /// </summary>
        public const char Read = 'r';

        /// <summary>
        /// w
        /// </summary>
        public const char Write = 'w';

        /// <summary>
        /// x
        /// </summary>
        public const char Execute = 'x';

        /// <summary>
        /// --- 000 [0]
        /// </summary>
        public const string N = "---"; // 0

        /// <summary>
        /// --x 001 [1]
        /// </summary>
        public const string E = "--x"; // 1

        /// <summary>
        /// -w- 010 [2]
        /// </summary>
        public const string W = "-w-"; // 2

        /// <summary>
        /// -wx 011 [3]
        /// </summary>
        public const string WE = "-wx"; // 3

        /// <summary>
        /// r-- 100 [4]
        /// </summary>
        public const string R = "r--"; // 4

        /// <summary>
        /// r-x 101 [5]
        /// </summary>
        public const string RE = "r-x"; // 5

        /// <summary>
        /// rw- 110 [6]
        /// </summary>
        public const string RW = "rw-"; // 6

        /// <summary>
        /// rwx 111 [7]
        /// </summary>
        public const string RWE = "rwx"; // 7
    }
}

