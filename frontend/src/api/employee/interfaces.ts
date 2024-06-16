export interface CreateEmployeeDto {
    fullName: string;
    subdivision?: string;
    position?: string;
    status: string;
    peoplePartnerId?: number;
    outOfOfficeBalance: number;
    photo?: File;
    identityId: string;
}

export interface Employee {
    id: number;
    fullName: string;
    subdivision?: string;
    position?: string;
    status: string;
    peoplePartnerId?: number;
    outOfOfficeBalance: number;
    photo?: File;
    identityId: string;
}