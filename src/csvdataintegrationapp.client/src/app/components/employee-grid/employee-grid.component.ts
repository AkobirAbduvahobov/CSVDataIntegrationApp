import { Component, OnInit } from '@angular/core';
import { EmployeeLocalService } from '../../services/employee-local.service';
import { EmployeeModel } from '../../services/models/employee';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-grid',
  templateUrl: './employee-grid.component.html',
  styleUrl: './employee-grid.component.css'
})

export class EmployeeGridComponent implements OnInit {
  
  constructor(private employeeService: EmployeeLocalService, private formBuilder: FormBuilder, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }


  public employees: EmployeeModel[] = [];
  public currentEmployee: EmployeeModel = this.getEmptyEmployee();
  public isModalOpen = false;
  public modalTitle = 'Add Employee';
  public selectedFile: File | null = null;
  public uploadStatus: string | null = null;


  public loadEmployees(search?: string, sortColumn: string = 'surname', sortAscending: boolean = true): void {
    debugger;
    this.employeeService.getAllEmployees(search, sortColumn, sortAscending).subscribe({
      next: (dataEmployees) => {
        debugger;
        this.employees = dataEmployees
      },
      error: (err) => {
        console.error('Error loading employees:', err);
      }
    });
  }


  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input?.files?.length) {
      this.selectedFile = input.files[0];
      this.uploadStatus = null; // Clear any previous status
    }
  }

  uploadFile(): void {
    if (this.selectedFile) {
      this.employeeService.uploadCsv(this.selectedFile).subscribe({
        next: (response) => {
          this.uploadStatus = `${response} files uploaded successfully`;
          this.toastr.success(`${this.uploadStatus}`);
          this.loadEmployees();
        },
        error: (err) => {
          
        }
      });
    }
  }


  public deleteEmployee(employee: EmployeeModel): void {
    console.log(employee);
    this.employeeService.deleteEmployee(employee.id!).subscribe({
      next: (response) => {
        this.toastr.success('Employee deleted successfully!');
        this.loadEmployees();
      },
      error: (err) => {
        this.loadEmployees();
      }
    });
  }


  public openModal(employee?: EmployeeModel): void {
    this.isModalOpen = true;
    this.modalTitle = employee ? 'Edit Employee' : 'Add Employee';
    this.currentEmployee = employee ? { ...employee } : this.getEmptyEmployee();
  }


  public closeModal(): void {
    this.isModalOpen = false;
    this.currentEmployee = this.getEmptyEmployee();
  }


  public onSubmit(): void {
    if (this.currentEmployee.id) {
      this.employeeService.updateEmployee(this.currentEmployee).subscribe({
        next: () => {
          this.toastr.success('Employee updated successfully!');
          this.loadEmployees();
          this.closeModal();
        },
        error: (err) => console.error('Error updating employee', err),
      });
    } else {
      this.employeeService.addEmployee(this.currentEmployee).subscribe({
        next: () => {
          this.toastr.success('Employee added successfully!');
          this.loadEmployees();
          this.closeModal();
        },
        error: (err) => console.error('Error adding employee', err),
      });
    }
  }


  private getEmptyEmployee(): EmployeeModel {
    return {
      address: null,
      address2: null,
      dateOfBirth: new Date(),
      emailHome: null,
      forenames: null,
      id: undefined,
      mobile: null,
      payrollNumber: null,
      postcode: null,
      startDate: new Date(),
      surname: null,
      telephone: null,
    };
  }


}