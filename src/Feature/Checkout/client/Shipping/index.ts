//    Copyright 2020 EPAM Systems, Inc.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

import { withExperienceEditorChromes } from '@sitecore-jss/sitecore-jss-react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { LoadingStatus } from 'Foundation/Integration/client';

import * as Checkout from 'Feature/Checkout/client/Integration/Checkout';

import ShippingComponent from './Component';
import { AppState, ShippingDispatchProps, ShippingOwnProps, ShippingStateProps } from './models';

const mapStateToProps = (state: AppState): ShippingStateProps => {
  const commerceUser = Checkout.commerceUser(state);
  const deliveryData = Checkout.checkoutDeliveryData(state);
  const shippingData = Checkout.checkoutShippingData(state);
  const currentStep = Checkout.currentStep(state);

  return {
    commerceUser,
    deliveryData,
    isLoading: deliveryData.status === LoadingStatus.Loading || shippingData.status === LoadingStatus.Loading,
    isSubmitting: currentStep.status === LoadingStatus.Loading,
    shippingData,
  };
};

const mapDispatchToProps = (dispatch: any) => {
  return bindActionCreators(
    {
      InitStep: Checkout.InitStep,
      SubmitStep: Checkout.SubmitStep,
    },
    dispatch
  );
};

const connectedToStore = connect<ShippingStateProps, ShippingDispatchProps, ShippingOwnProps>(
  mapStateToProps,
  mapDispatchToProps
)(ShippingComponent);

export const Shipping = withExperienceEditorChromes(connectedToStore);
