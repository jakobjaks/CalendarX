import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {OrganizationService} from "../../services/organization-service";
import {IOrganization} from "../../interfaces/IOrganization";

export var log = LogManager.getLogger('Organization.Delete');

@autoinject
export class Delete {

  private organization: IOrganization;

  constructor(
    private router: Router,
    private organizationService: OrganizationService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============
  submit():void{
    log.debug('organization', this.organization);
    this.organizationService.put(this.organization!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("OrganizationsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
  }


  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);

    this.organizationService.fetch(params.id).then(
      organization => {
        log.debug('organization', organization);
        this.organization = organization;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
