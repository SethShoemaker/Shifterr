export interface ShiftShowCoworkerDto{
    shiftId: number;
    nickname: string;
}

export interface ShiftShowResponseBody{
    worker: string;
    hours: number;
    position: string | null;
    startDate: Date;
    startTime: string;
    endTime: string;
    coWorkers: ShiftShowCoworkerDto[];
}