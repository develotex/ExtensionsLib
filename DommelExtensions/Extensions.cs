using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using Dommel;
using MySql.Data.MySqlClient;

namespace DommelExtensions
{
    public static class Extensions
    {
        public static int InsertInt<T>(this IDbConnection conn, T entity) where T : class
        {
            var id = (ulong) conn.Insert<T>(entity);
            return Convert.ToInt32(id);
        }

        /// <summary>
        /// Returns null if insert has failed.
        /// </summary>
        public static object InsertIgnore<T>(this IDbConnection conn, T entity) where T : class
        {
            try
            {
                return conn.Insert<T>(entity);
            }
            catch (MySqlException ex)
            {
                switch ((MySqlErrorCode) ex.Number)
                {
                    case MySqlErrorCode.DuplicateEntryWithKeyName:
                    case MySqlErrorCode.DuplicateKeyEntry:
                        return null;
                    default:
                        throw;
                }
            }
        }

        public static bool IsExists<T>(this IDbConnection db, Expression<Func<T, bool>> selector)
        {
            return db.Count<T>(selector) > 0;
        }

        /// <summary>
        /// Read multiple objects from a single record set on the grid
        /// </summary>
        /// <param name="gr">Grid reader</param>
        /// <typeparam name="TFirst">The first type in the record set.</typeparam>
        /// <typeparam name="TSecond">The second type in the record set.</typeparam>
        /// <typeparam name="TThird">The third type in the record set.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the record set.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the record set.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the record set.</typeparam>
        /// <typeparam name="TSeventh">The seventh type in the record set.</typeparam>
        /// <typeparam name="TEighth">The eighth type in the record set.</typeparam>
        /// <typeparam name="TReturn">The type to return from the record set.</typeparam>
        /// <param name="func">The mapping function from the read types to the return type.</param>
        /// <param name="splitOn">The field(s) we should split and read the second object from (defaults to "id")</param>
        /// <param name="buffered">Whether to buffer results in memory.</param>
        public static IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TReturn>(
            this SqlMapper.GridReader gr,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TReturn> func,
            string splitOn = "id", bool buffered = true)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TSeventh : class
            where TEighth : class
        {
            var objFunc = new Func<object[], TReturn>(objArr =>
            {
                var first = objArr[0] as TFirst;
                var second = objArr[1] as TSecond;
                var third = objArr[2] as TThird;
                var fourth = objArr[3] as TFourth;
                var fifth = objArr[4] as TFifth;
                var sixth = objArr[5] as TSixth;
                var seventh = objArr[6] as TSeventh;
                var eighth = objArr[7] as TEighth;
                return func(first, second, third, fourth, fifth, sixth, seventh, eighth);
            });
            var result =
                gr.Read<TReturn>(new[] { typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(TFifth), typeof(TSixth), typeof(TSeventh), typeof(TEighth) },
                    objFunc, splitOn, buffered);
            return result;
        }

        /// <summary>
        /// Read multiple objects from a single record set on the grid
        /// </summary>
        /// <param name="gr">Grid reader</param>
        /// <typeparam name="TFirst">The first type in the record set.</typeparam>
        /// <typeparam name="TSecond">The second type in the record set.</typeparam>
        /// <typeparam name="TThird">The third type in the record set.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the record set.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the record set.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the record set.</typeparam>
        /// <typeparam name="TSeventh">The seventh type in the record set.</typeparam>
        /// <typeparam name="TEighth">The eighth type in the record set.</typeparam>
        /// <typeparam name="TNinth">The ninth type in the record set.</typeparam>
        /// <typeparam name="TReturn">The type to return from the record set.</typeparam>
        /// <param name="func">The mapping function from the read types to the return type.</param>
        /// <param name="splitOn">The field(s) we should split and read the second object from (defaults to "id")</param>
        /// <param name="buffered">Whether to buffer results in memory.</param>
        public static IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TReturn>(
            this SqlMapper.GridReader gr,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TReturn> func,
            string splitOn = "id", bool buffered = true)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TSeventh : class
            where TEighth : class
            where TNinth : class
        {
            var objFunc = new Func<object[], TReturn>(objArr =>
            {
                var first = objArr[0] as TFirst;
                var second = objArr[1] as TSecond;
                var third = objArr[2] as TThird;
                var fourth = objArr[3] as TFourth;
                var fifth = objArr[4] as TFifth;
                var sixth = objArr[5] as TSixth;
                var seventh = objArr[6] as TSeventh;
                var eighth = objArr[7] as TEighth;
                var nineth = objArr[8] as TNinth;
                return func(first, second, third, fourth, fifth, sixth, seventh, eighth, nineth);
            });
            var result =
                gr.Read<TReturn>(new[] { typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(TFifth), typeof(TSixth), typeof(TSeventh), typeof(TEighth), typeof(TNinth), },
                    objFunc, splitOn, buffered);
            return result;
        }
    }
}