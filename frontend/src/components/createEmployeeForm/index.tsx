import React, { useState, ChangeEvent, FormEvent } from 'react';
import {create, CreateEmployeeDto} from "../../api/employee";


interface FormState extends Omit<CreateEmployeeDto, 'photo'> {
    photo?: File;
}

const CreateEmployeeForm: React.FC = () => {
    const [formData, setFormData] = useState<FormState>({
        fullName: '',
        subdivision: '',
        position: '',
        status: '',
        peoplePartnerId: undefined,
        outOfOfficeBalance: 0,
        identityId: '',
        photo: undefined
    });

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [name]: name === 'peoplePartnerId' || name === 'outOfOfficeBalance' ? Number(value) : value
        }));
    };
    
    const handleFileChange = (e: ChangeEvent<HTMLInputElement>): void => {

        if (e.target.files && e.target.files.length > 0) {
            
            setFormData((prev) => ({
                ...prev,
                // @ts-ignore
                photo: e.target.files[0]
            }));
        }
    };

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        const data = new FormData();
        Object.keys(formData).forEach((key) => {
            const value = (formData as any)[key];
            if (value !== undefined) {
                data.append(key, value);
            }
        });

        try {
            const newEmployee = await create(formData as unknown as CreateEmployeeDto);
            console.log(newEmployee);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column' }}>
            <input
                type="text"
                name="fullName"
                placeholder="Full Name"
                value={formData.fullName}
                onChange={handleChange}
                required
            />
            <input
                type="text"
                name="subdivision"
                placeholder="Subdivision"
                value={formData.subdivision}
                onChange={handleChange}
            />
            <input
                type="text"
                name="position"
                placeholder="Position"
                value={formData.position}
                onChange={handleChange}
            />
            <input
                type="text"
                name="status"
                placeholder="Status"
                value={formData.status}
                onChange={handleChange}
            />
            <input
                type="number"
                name="peoplePartnerId"
                placeholder="People Partner ID"
                value={formData.peoplePartnerId}
                onChange={handleChange}
            />
            <input
                type="number"
                name="outOfOfficeBalance"
                placeholder="Out of Office Balance"
                value={formData.outOfOfficeBalance}
                onChange={handleChange}
            />
            <input
                type="text"
                name="identityId"
                placeholder="Identity ID"
                value={formData.identityId}
                onChange={handleChange}
                required
            />
            <input
                type="file"
                name="photo"
                onChange={handleFileChange}
                required
            />
            <button type="submit">Create Employee</button>
        </form>
    );
};

export default CreateEmployeeForm;
