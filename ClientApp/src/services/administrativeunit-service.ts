import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IAdministrativeUnit} from "../interfaces/IAdministrativeUnit";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('AdministrativeunitService');

@autoinject
export class AdministrativeUnitService extends BaseService<IAdministrativeUnit> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'AdministrativeUnit');
  }

}
