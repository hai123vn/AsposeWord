namespace API.Helpers.Utilities
{
    public static class DatetimeUtility
    {
        /// <summary>
        /// Lấy Ngày tháng năm , không lấy giờ
        /// </summary>
        /// <param name="date"></param>
        /// <returns> 12/01/2022 00:00:00 </returns>
        public static DateTime DatetimeToDateNotHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
    }
}