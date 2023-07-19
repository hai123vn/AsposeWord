declare global {
    interface Date {
        toDate(): Date;
        toUTCDate(): Date;
        toStringDate(): string;
        toStringTime(): string;
        toStringDateTime(): string;
        toStringYearMonth(): string;
        toStringMonth(): string;
        toFirstDateOfMonth(): Date;
        toLastDateOfMonth(): Date;
        toFirstDateOfYear(): Date;
        toLastDateOfYear(): Date;
        toBeginDate(): Date;
        toEndDate(): Date;
    }

    interface String {
        toDate(): Date;
        toUTCDate(): Date;
        toInt(): number;
        toFloat(): number;
    }

    interface Number {

        toStringLeadingZeros(targetLength: number): string;
    }
}

// Nhận vào string , trả về ngày
Date.prototype.toDate = function (): Date {
    const _this = this;
    //   const _this = this as string;
    return new Date(_this);
}

Date.prototype.toUTCDate = function (): Date {
    const _this = this as Date;
    return new Date(Date.UTC(
        _this.getFullYear(),
        _this.getMonth(),
        _this.getDate(),
        _this.getHours(),
        _this.getMinutes(),
        _this.getSeconds(),
        _this.getMilliseconds()));
}

Date.prototype.toStringDate = function (): string {
    const _this = this as Date;
    const year = _this.getFullYear();
    const month = (_this.getMonth() + 1).toStringLeadingZeros(2);
    const date = _this.getDate().toStringLeadingZeros(2);
    return `${year}/${month}/${date}`;
}

Date.prototype.toStringTime = function (): string {
    const _this = this as Date;
    const hours = _this.getHours().toStringLeadingZeros(2);
    const minutes = _this.getMinutes().toStringLeadingZeros(2);
    const seconds = _this.getSeconds().toStringLeadingZeros(2);
    return `${hours}:${minutes}:${seconds}`;
}

Date.prototype.toStringDateTime = function (): string {
    const _this = this as Date;
    const year = _this.getFullYear();
    const month = (_this.getMonth() + 1).toStringLeadingZeros(2);
    const date = _this.getDate().toStringLeadingZeros(2);
    const hours = _this.getHours().toStringLeadingZeros(2);
    const minutes = _this.getMinutes().toStringLeadingZeros(2);
    const seconds = _this.getSeconds().toStringLeadingZeros(2);
    return `${year}/${month}/${date} ${hours}:${minutes}:${seconds}`;
}

Date.prototype.toStringYearMonth = function (): string {
    const _this = this as Date;
    const year = _this.getFullYear();
    const month = (_this.getMonth() + 1).toStringLeadingZeros(2);
    return `${year}/${month}`;
}

Date.prototype.toStringMonth = function (): string {
    const _this = this as Date;
    const month = (_this.getMonth() + 1).toStringLeadingZeros(2);
    return `${month}`;
}

Date.prototype.toFirstDateOfMonth = function (): Date {
    const _this = this as Date;
    return new Date(_this.getFullYear(), _this.getMonth(), 1);
}

Date.prototype.toLastDateOfMonth = function (): Date {
    const _this = this as Date;
    return new Date(_this.getFullYear(), _this.getMonth() + 1, 0);
}

Date.prototype.toFirstDateOfYear = function (): Date {
    const _this = this as Date;
    return new Date(_this.getFullYear(), 0, 1);
}

Date.prototype.toLastDateOfYear = function (): Date {
    const _this = this as Date;
    return new Date(_this.getFullYear(), 11, 31);
}

Date.prototype.toBeginDate = function (): Date {
    const _this = this as Date;
    _this.setHours(0, 0, 0);
    return _this;
}

Date.prototype.toEndDate = function (): Date {
    const _this = this as Date;
    _this.setHours(23, 59, 59);
    return _this;
}

String.prototype.toDate = function (): Date {
    const _this = this as string;
    return new Date(_this);
}

String.prototype.toUTCDate = function (): Date {
    const _this = this as string;
    return _this.toDate().toUTCDate();
}
String.prototype.toInt = function (): number {
    const _this = this as string;
    return Number.parseInt(_this);
}
String.prototype.toFloat = function (): number {
    const _this = this as string;
    return Number.parseFloat(_this);
}

Number.prototype.toStringLeadingZeros = function (targetLength: number): string {
    const _this = this as number;
    return String(_this).padStart(targetLength, '0');
}

export { };
