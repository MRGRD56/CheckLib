using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckLib
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Returns a checkable items collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public static IEnumerable<Checkable<T>> ToCheckableList<T>(this IEnumerable<T> collection, bool isChecked = false) =>
            collection.Select(x => new Checkable<T>(x, isChecked));

        /// <summary>
        /// Returns the items from the <paramref name="collection"/>, where IsChecked == <paramref name="isChecked"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public static IEnumerable<Checkable<T>> GetChecked<T>(this IEnumerable<Checkable<T>> collection, bool isChecked = true) =>
            collection.Where(x => x.IsChecked == isChecked);

        /// <summary>
        /// Returns the items' Item property for each item from the <paramref name="collection"/>. <br/>
        /// If <paramref name="isChecked"/> is not null, filters the <paramref name="collection"/> by IsChecked property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetItems<T>(this IEnumerable<Checkable<T>> collection, bool? isChecked = null) =>
            collection.Where(x => !isChecked.HasValue || x.IsChecked == isChecked).Select(x => x.Item);
    }
}
