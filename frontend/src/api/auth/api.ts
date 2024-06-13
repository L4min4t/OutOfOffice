import {CHANGE_PASSWORD_URL, LOGIN_URL, REFRESH_URL, REGISTER_URL} from "./urls";

import {Jwts} from "./interfaces";

import {defaultFetch, processResponse, protectedFetch} from "../common";

export const login = async (
    email: string,
    password: string
): Promise<Jwts | null> => {
    const response = await defaultFetch<Jwts>(LOGIN_URL, {
        method: "post",
        data: {email, password},
    });

    return processResponse(response);
};

export const register = async (
    email: string,
    name: string,
    password: string
): Promise<void | null> => {
    const response = await defaultFetch<void>(REGISTER_URL, {
        method: "post",
        data: {email, name, password},
    });

    return processResponse(response);
};

export const refreshToken = async (
    email: string,
    tokens: Jwts
): Promise<Jwts | null> => {
    const response = await protectedFetch<Jwts>(
        REFRESH_URL,
        tokens.accessToken,
        {
            method: "post",
            data: {
                email,
                ...tokens,
            },
        }
    );

    return processResponse(response);
};

export const changePassword = async (
    token: string,
    email: string,
    oldPassword: string,
    newPassword: string
): Promise<Jwts | null> => {
    const result = await protectedFetch<Jwts>(
        CHANGE_PASSWORD_URL,
        token,
        {
            method: "post",
            data: {
                email,
                oldPassword,
                newPassword
            }
        }
    );

    return processResponse(result);
}

