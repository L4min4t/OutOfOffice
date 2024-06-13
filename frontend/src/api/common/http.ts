import axios, {AxiosError, AxiosRequestConfig} from "axios";
import {ApiResponse} from "./interfaces";

export const defaultFetch = async <T>(
    url: string,
    config: AxiosRequestConfig = {}
): Promise<ApiResponse<T>> => {
    const defaultConfig: AxiosRequestConfig = {
        headers: {
            "Content-Type": "application/json",
        },
        ...config,
    };

    try {
        const response = await axios(url, defaultConfig);
        return {data: response.data, status: response.status};
    } catch (error) {
        if (axios.isAxiosError(error)) {
            const err = error as AxiosError;
            if (err.response?.data) {
                return {status: err.response.status, error: err.response.data || "An error occurred!"};
            }
        }
        return {status: 500, error: "Server is faulty!"};
    }
};

export const protectedFetch = async <T>(
    url: string,
    token: string,
    config: AxiosRequestConfig = {}
): Promise<ApiResponse<T>> => {
    const authConfig: AxiosRequestConfig = {
        ...config,
        headers: {
            ...config.headers,
            Authorization: `Bearer ${token}`,
        },
    };
    return defaultFetch<T>(url, authConfig);
};