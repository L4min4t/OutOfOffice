import {defaultFetch, processResponse,} from "../common";
import {CreateEmployeeDto, Employee} from "./interfaces";
import {CREATE_EMPLOYEE_URL} from "./urls";

export const create = async (employee: CreateEmployeeDto): Promise<Employee | null> => {
    const result = await defaultFetch<Employee>(
        CREATE_EMPLOYEE_URL,
        {
            method: "post",
            data: {
                employee
            }
        }
    );
    return processResponse(result);
}