export class CalendarIndexShiftDto{
    id: number = null!;
    startDate: string = null!;
    startTime: string = null!;
    endTime: string = null!;
    position: string = null!;
}

export class CalendarIndexWorkerDto{
    nickname: string = null!;
    shifts: CalendarIndexShiftDto[] = [];
}

export class CalendarIndexResponse{
    workers: CalendarIndexWorkerDto[] = [];
}