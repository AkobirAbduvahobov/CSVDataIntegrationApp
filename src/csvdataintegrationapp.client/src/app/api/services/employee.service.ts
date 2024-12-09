/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { apiEmployeeAddPost$Json } from '../fn/employee/api-employee-add-post-json';
import { ApiEmployeeAddPost$Json$Params } from '../fn/employee/api-employee-add-post-json';
import { apiEmployeeAddPost$Plain } from '../fn/employee/api-employee-add-post-plain';
import { ApiEmployeeAddPost$Plain$Params } from '../fn/employee/api-employee-add-post-plain';
import { apiEmployeeDeleteDelete } from '../fn/employee/api-employee-delete-delete';
import { ApiEmployeeDeleteDelete$Params } from '../fn/employee/api-employee-delete-delete';
import { apiEmployeeGetAllGet$Json } from '../fn/employee/api-employee-get-all-get-json';
import { ApiEmployeeGetAllGet$Json$Params } from '../fn/employee/api-employee-get-all-get-json';
import { apiEmployeeGetAllGet$Plain } from '../fn/employee/api-employee-get-all-get-plain';
import { ApiEmployeeGetAllGet$Plain$Params } from '../fn/employee/api-employee-get-all-get-plain';
import { apiEmployeeGetByIdGet$Json } from '../fn/employee/api-employee-get-by-id-get-json';
import { ApiEmployeeGetByIdGet$Json$Params } from '../fn/employee/api-employee-get-by-id-get-json';
import { apiEmployeeGetByIdGet$Plain } from '../fn/employee/api-employee-get-by-id-get-plain';
import { ApiEmployeeGetByIdGet$Plain$Params } from '../fn/employee/api-employee-get-by-id-get-plain';
import { apiEmployeeUpdatePut } from '../fn/employee/api-employee-update-put';
import { ApiEmployeeUpdatePut$Params } from '../fn/employee/api-employee-update-put';
import { apiEmployeeUploadCsvPost$Json } from '../fn/employee/api-employee-upload-csv-post-json';
import { ApiEmployeeUploadCsvPost$Json$Params } from '../fn/employee/api-employee-upload-csv-post-json';
import { apiEmployeeUploadCsvPost$Plain } from '../fn/employee/api-employee-upload-csv-post-plain';
import { ApiEmployeeUploadCsvPost$Plain$Params } from '../fn/employee/api-employee-upload-csv-post-plain';
import { EmployeeDto } from '../models/employee-dto';

@Injectable({ providedIn: 'root' })
export class EmployeeService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /** Path part for operation `apiEmployeeAddPost()` */
  static readonly ApiEmployeeAddPostPath = '/api/employee/add';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeAddPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEmployeeAddPost$Plain$Response(params?: ApiEmployeeAddPost$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<string>> {
    return apiEmployeeAddPost$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeAddPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEmployeeAddPost$Plain(params?: ApiEmployeeAddPost$Plain$Params, context?: HttpContext): Observable<string> {
    return this.apiEmployeeAddPost$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<string>): string => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeAddPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEmployeeAddPost$Json$Response(params?: ApiEmployeeAddPost$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<string>> {
    return apiEmployeeAddPost$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeAddPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEmployeeAddPost$Json(params?: ApiEmployeeAddPost$Json$Params, context?: HttpContext): Observable<string> {
    return this.apiEmployeeAddPost$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<string>): string => r.body)
    );
  }

  /** Path part for operation `apiEmployeeGetByIdGet()` */
  static readonly ApiEmployeeGetByIdGetPath = '/api/employee/getById';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeGetByIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetByIdGet$Plain$Response(params?: ApiEmployeeGetByIdGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<EmployeeDto>> {
    return apiEmployeeGetByIdGet$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeGetByIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetByIdGet$Plain(params?: ApiEmployeeGetByIdGet$Plain$Params, context?: HttpContext): Observable<EmployeeDto> {
    return this.apiEmployeeGetByIdGet$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<EmployeeDto>): EmployeeDto => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeGetByIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetByIdGet$Json$Response(params?: ApiEmployeeGetByIdGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<EmployeeDto>> {
    return apiEmployeeGetByIdGet$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeGetByIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetByIdGet$Json(params?: ApiEmployeeGetByIdGet$Json$Params, context?: HttpContext): Observable<EmployeeDto> {
    return this.apiEmployeeGetByIdGet$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<EmployeeDto>): EmployeeDto => r.body)
    );
  }

  /** Path part for operation `apiEmployeeDeleteDelete()` */
  static readonly ApiEmployeeDeleteDeletePath = '/api/employee/delete';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeDeleteDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeDeleteDelete$Response(params?: ApiEmployeeDeleteDelete$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiEmployeeDeleteDelete(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeDeleteDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeDeleteDelete(params?: ApiEmployeeDeleteDelete$Params, context?: HttpContext): Observable<void> {
    return this.apiEmployeeDeleteDelete$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `apiEmployeeUpdatePut()` */
  static readonly ApiEmployeeUpdatePutPath = '/api/employee/update';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeUpdatePut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEmployeeUpdatePut$Response(params?: ApiEmployeeUpdatePut$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiEmployeeUpdatePut(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeUpdatePut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEmployeeUpdatePut(params?: ApiEmployeeUpdatePut$Params, context?: HttpContext): Observable<void> {
    return this.apiEmployeeUpdatePut$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `apiEmployeeUploadCsvPost()` */
  static readonly ApiEmployeeUploadCsvPostPath = '/api/employee/uploadCSV';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeUploadCsvPost$Plain()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEmployeeUploadCsvPost$Plain$Response(params?: ApiEmployeeUploadCsvPost$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<number>> {
    return apiEmployeeUploadCsvPost$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeUploadCsvPost$Plain$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEmployeeUploadCsvPost$Plain(params?: ApiEmployeeUploadCsvPost$Plain$Params, context?: HttpContext): Observable<number> {
    return this.apiEmployeeUploadCsvPost$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<number>): number => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeUploadCsvPost$Json()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEmployeeUploadCsvPost$Json$Response(params?: ApiEmployeeUploadCsvPost$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<number>> {
    return apiEmployeeUploadCsvPost$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeUploadCsvPost$Json$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEmployeeUploadCsvPost$Json(params?: ApiEmployeeUploadCsvPost$Json$Params, context?: HttpContext): Observable<number> {
    return this.apiEmployeeUploadCsvPost$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<number>): number => r.body)
    );
  }

  /** Path part for operation `apiEmployeeGetAllGet()` */
  static readonly ApiEmployeeGetAllGetPath = '/api/employee/getAll';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeGetAllGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetAllGet$Plain$Response(params?: ApiEmployeeGetAllGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<EmployeeDto>>> {
    return apiEmployeeGetAllGet$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeGetAllGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetAllGet$Plain(params?: ApiEmployeeGetAllGet$Plain$Params, context?: HttpContext): Observable<Array<EmployeeDto>> {
    return this.apiEmployeeGetAllGet$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<Array<EmployeeDto>>): Array<EmployeeDto> => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEmployeeGetAllGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetAllGet$Json$Response(params?: ApiEmployeeGetAllGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<EmployeeDto>>> {
    return apiEmployeeGetAllGet$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEmployeeGetAllGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEmployeeGetAllGet$Json(params?: ApiEmployeeGetAllGet$Json$Params, context?: HttpContext): Observable<Array<EmployeeDto>> {
    return this.apiEmployeeGetAllGet$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<Array<EmployeeDto>>): Array<EmployeeDto> => r.body)
    );
  }

}
