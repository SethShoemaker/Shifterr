export interface ShiftsCreateInfoPositionDto{
    id: number;
    name: string;
}

export interface ShiftsCreateInfoWorkerDto{
    id: number;
    nickname: string;
    userName: string;
}

export interface ShiftsCreateInfoResponseBody{
    positions: ShiftsCreateInfoPositionDto[];
    workers: ShiftsCreateInfoWorkerDto[];
}