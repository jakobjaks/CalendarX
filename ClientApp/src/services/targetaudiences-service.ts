import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {ITargetAudience} from "../interfaces/ITargetAudience";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('TargetAudienceService');

@autoinject
export class TargetAudienceService extends BaseService<ITargetAudience> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'TargetAudience');
  }

}
