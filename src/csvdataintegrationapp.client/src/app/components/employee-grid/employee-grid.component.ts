import { Component, OnInit } from '@angular/core';
import { EmployeeLocalService } from '../../services/employee-local.service';
import { EmployeeModel } from '../../services/models/employee';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { debounceTime, Subject } from 'rxjs';
import { SortDescriptor } from '@progress/kendo-data-query';

@Component({
  selector: 'app-employee-grid',
  templateUrl: './employee-grid.component.html',
  styleUrl: './employee-grid.component.css'
})

export class EmployeeGridComponent implements OnInit {
    constructor(private employeeService: EmployeeLocalService, private formBuilder: FormBuilder, private toastr: ToastrService) {
    this.searchSubject.pipe(debounceTime(500)).subscribe((searchTerm) => {
      this.loadEmployees();
    });
  }

  public employees: EmployeeModel[] = [];
  public currentEmployee: EmployeeModel = this.getEmptyEmployee();
  public isModalOpen = false;
  public modalTitle = 'Add Employee';
  public selectedFile: File | null = null;
  public uploadStatus: string | null = null;
  public sortColumn = 'surname';
  public sortAscending = true;
  public searchTerm: string = '';
  private searchSubject: Subject<string> = new Subject<string>();
  public sort: SortDescriptor[] = [];

  ngOnInit(): void {
    this.loadEmployees();
  }

  public onSortChange(sort: SortDescriptor[]): void {
    this.sort = sort;
    this.employees = this.sortData(this.employees, sort);
  }

  public sortData(data: EmployeeModel[], sort: SortDescriptor[]): EmployeeModel[] {
    if (!sort || sort.length === 0) {
      return data;
    }

    return [...data].sort((a, b) => {
      for (const descriptor of sort) {
        const field = descriptor.field!;
        const dir = descriptor.dir === 'asc' ? 1 : -1;
        const aValue = this.getFieldValue(a, field);
        const bValue = this.getFieldValue(b, field);

        if (aValue == null && bValue != null) return -1 * dir;
        if (aValue != null && bValue == null) return 1 * dir;
        if (aValue == null && bValue == null) continue;

        if (typeof aValue === 'string' && typeof bValue === 'string') {
          const result = aValue.localeCompare(bValue) * dir;
          if (result !== 0) return result;
        } else if (aValue > bValue) {
          return 1 * dir;
        } else if (aValue < bValue) {
          return -1 * dir;
        }
      }
      return 0;
    });
  }

  public getFieldValue(obj: any, field: string): any {
    return field.split('.').reduce((o, i) => (o ? o[i] : null), obj);
  }

  public loadEmployees(): void {
    this.employeeService.getAllEmployees(this.searchTerm, this.sortColumn, this.sortAscending).subscribe({
      next: (dataEmployees) => {
        debugger;
        this.employees = dataEmployees
      },
      error: (err) => {
        console.error('Error loading employees:', err);
      }
    });
  }

  public onSearchChange(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.searchTerm = target.value;
    this.searchSubject.next(this.searchTerm);
  }

  public executeSearch() : void {
    this.loadEmployees();
  }

  public onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input?.files?.length) {
      this.selectedFile = input.files[0];
      this.uploadStatus = null; // Clear any previous status
    }
  }

  public uploadFile(): void {
    if (this.selectedFile) {
      this.employeeService.uploadCsv(this.selectedFile).subscribe({
        next: (response) => {
          this.uploadStatus = `${response} files uploaded successfully`;
          this.toastr.success(`${this.uploadStatus}`);
          this.loadEmployees();
        },
        error: (err) => {
          this.toastr.error(`Error :  ${err.text}`);
        }
      });
    }
  }

  public deleteEmployee(employee: EmployeeModel): void {
    this.employeeService.deleteEmployee(employee.id!).subscribe({
      next: (response) => {
        this.toastr.success('Employee deleted successfully!');
        this.loadEmployees();
      },
      error: (err) => {
        this.loadEmployees();
        this.toastr.error(`Error :  ${err.text}`);
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
        error: (err) => {
          this.loadEmployees();
          this.toastr.error(`Error while updating`);
          this.closeModal();
        }
      });
    } else {
      this.employeeService.addEmployee(this.currentEmployee).subscribe({
        next: () => {
          this.toastr.success('Employee added successfully!');
          this.loadEmployees();
          this.closeModal();
        },
        error: (err) => {
          this.loadEmployees();
          this.toastr.error(`Error while adding`);
          this.closeModal();
        }
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