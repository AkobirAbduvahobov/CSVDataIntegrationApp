export class CreateEmployeeModel {
    address?: string | null;
    address2?: string | null;
    dateOfBirth: Date = new Date();
    emailHome?: string | null;
    forenames?: string | null;
    mobile?: string | null;
    payrollNumber?: string | null;
    postcode?: string | null;
    startDate: Date = new Date();
    surname?: string | null;
    telephone?: string | null;
  }