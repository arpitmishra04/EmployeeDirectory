export interface EmployeeModel {
  employeeId: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  email: string;
  mobileNumber: string;
  joiningDate: string;
  employeeProfilePic: string | null;
  managerId: string | null;
  projectId: number;
  projectName: string;
  statusId: number;
  statusName: string;
  roleId: number;
  roleName: string;
  departmentId: number;
  departmentName: string;
  locationId: number;
  locationName: string;
}
