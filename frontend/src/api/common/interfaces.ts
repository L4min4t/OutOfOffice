export type ApiResponse<T> =
    | { data: T; status: number; }
    | { status: number; error: any; };