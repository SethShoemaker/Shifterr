export interface ShiftIndexResponseBody{
    id: number;
    positionId: number | null;
    position: string | null;
    workerId: number;
    worker: string;
    start: Date;
    end: Date;
}