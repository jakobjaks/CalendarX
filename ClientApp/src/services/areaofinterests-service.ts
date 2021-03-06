import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IAreaOfInterest} from "../interfaces/IAreaOfInterest";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('AreaofinterestService');

@autoinject
export class AreaOfInterestService extends BaseService<IAreaOfInterest> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'AreaOfInterest');
  }

}
