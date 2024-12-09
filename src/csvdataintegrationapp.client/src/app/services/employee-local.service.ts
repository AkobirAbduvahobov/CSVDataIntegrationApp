import { map, Observable } from "rxjs";
import { CreateEmployeeDto, EmployeeDto } from "../api/models";
import { EmployeeService } from "../api/services";
import { CreateEmployeeModel } from "./models/create-employee";
import { EmployeeModel } from "./models/employee";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root' 
  })

export class EmployeeLocalService {

    constructor(private employeeApiService: EmployeeService) { }

    public addEmployee(employee: CreateEmployeeModel): Observable<string> {
        const dto = this.mapToCreateEmployeeDto(employee);
        return this.employeeApiService.apiEmployeeAddPost$Json({ body: dto });
    }

    public uploadCsv(file: Blob): Observable<number> {
        const formData = new FormData();
        formData.append('file', file);
    
        return this.employeeApiService.apiEmployeeUploadCsvPost$Json({ body: { file } });
    }

    public updateEmployee(employee: EmployeeModel): Observable<void> {
        const dto = this.mapToEmployeeDto(employee);
        return this.employeeApiService.apiEmployeeUpdatePut$Response({ body: dto }).pipe(
            map(() => { })
        );
    }

    public deleteEmployee(id: string): Observable<void> {
        return this.employeeApiService.apiEmployeeDeleteDelete({ id }).pipe(
            map(() => { })
        );
    }

    public getEmployeeById(id: string): Observable<EmployeeModel> {
        return this.employeeApiService.apiEmployeeGetByIdGet$Plain({ id }).pipe(
            map((employeeDto: EmployeeDto) => this.mapToModel(employeeDto))
        );
    }

    public getAllEmployees(search?: string, sortColumn?: string, sortAscending?: boolean): Observable<EmployeeModel[]> {
        debugger;
        const params = {
            Search: search,
            SortColumn: sortColumn,
            SortAscending: sortAscending
        };

        const res = this.employeeApiService.apiEmployeeGetAllGet$Plain(params).pipe(
            map((response: any) => {
                const employeesDto = JSON.parse(response); 
                return employeesDto.map(this.mapToModel);
            })
        );

        return res;
    }


    private mapToModel(employeeDto: EmployeeDto): EmployeeModel {
        return {
            id: employeeDto.id,
            address: employeeDto.address,
            address2: employeeDto.address2,
            dateOfBirth: employeeDto.dateOfBirth ? new Date(employeeDto.dateOfBirth) : new Date(),
            emailHome: employeeDto.emailHome,
            forenames: employeeDto.forenames,
            mobile: employeeDto.mobile,
            payrollNumber: employeeDto.payrollNumber,
            postcode: employeeDto.postcode,
            startDate: employeeDto.startDate ? new Date(employeeDto.startDate) : new Date(),
            surname: employeeDto.surname,
            telephone: employeeDto.telephone
        }
    }

    private mapToCreateEmployeeDto(employee: CreateEmployeeModel): CreateEmployeeDto {

        const dateOfBirth = new Date(employee.dateOfBirth);
        const startDate = new Date(employee.startDate);

        return {
            address: employee.address,
            address2: employee.address2,
            dateOfBirth: dateOfBirth.toISOString(),
            emailHome: employee.emailHome,
            forenames: employee.forenames,
            mobile: employee.mobile,
            payrollNumber: employee.payrollNumber,
            postcode: employee.postcode,
            startDate: startDate.toISOString(),
            surname: employee.surname,
            telephone: employee.telephone
        };
    }

    private mapToEmployeeDto(employee: EmployeeModel): EmployeeDto {

        const dateOfBirth = new Date(employee.dateOfBirth);
        const startDate = new Date(employee.startDate);

        return {
            id: employee.id,
            address: employee.address,
            address2: employee.address2,
            dateOfBirth: dateOfBirth.toISOString(),
            emailHome: employee.emailHome,
            forenames: employee.forenames,
            mobile: employee.mobile,
            payrollNumber: employee.payrollNumber,
            postcode: employee.postcode,
            startDate: startDate.toISOString(),
            surname: employee.surname,
            telephone: employee.telephone
        };
    }
}